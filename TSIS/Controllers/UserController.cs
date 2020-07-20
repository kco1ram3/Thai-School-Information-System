using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSIS.Filters;
using NHibernate;
using TSIS.Models;
using TSIS.Classes;

namespace TSIS.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection collection)
        {
            string username = collection["Username"];
            string password = collection["Password"];
            iSISModel.User user = base.Context.PersistenceSession
                                      .QueryOver<iSISModel.User>()
                                      .Where(x => x.LoginName == username)
                                      .And(x => x.EffectivePeriod.To > DateTime.Today)
                                      .SingleOrDefault();
            string errorMessage = "";

            if (user != null)
            {
                if (user.CurrentPassword.Match(password))
                {
                    using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                    {
                        try
                        {
                            user.LastLoginTimestamp = DateTime.Now;
                            user.Persist(base.Context);

                            tran.Commit();
                        }
                        catch (Exception exc)
                        {
                            tran.Rollback();
                            throw exc;
                        }
                    }

                    iSISModel.UserRole userRole = base.Context.PersistenceSession
                                      .QueryOver<iSISModel.UserRole>()
                                      .Where(x => x.User == user)
                                      .And(x => x.EffectivePeriod.To > DateTime.Today)
                                      .SingleOrDefault();

                    IList<iSISModel.AuthorizeModule> authorizeModule = base.Context.PersistenceSession
                                      .QueryOver<iSISModel.AuthorizeModule>()
                                      .Where(x => x.Organization == user.Organization)
                                      .And(x => x.Role == userRole.Role)
                                      .And(x => x.EffectivePeriod.To > DateTime.Today)
                                      .List();

                    IList<iSISModel.AuthorizeScreen> authorizeScreen = base.Context.PersistenceSession
                                      .QueryOver<iSISModel.AuthorizeScreen>()
                                      .Where(x => x.Organization == user.Organization)
                                      .And(x => x.Role == userRole.Role)
                                      .And(x => x.EffectivePeriod.To > DateTime.Today)
                                      .List();

                    SessionManager.SetSession(this, SessionManager.SessionName.CurrentUser, user);
                    SessionManager.SetSession(this, SessionManager.SessionName.CurrentSchool, user.Organization);
                    SessionManager.SetSession(this, SessionManager.SessionName.CurrentRole, userRole.Role);
                    SessionManager.SetSession(this, SessionManager.SessionName.CurrentAuthorizeModule, authorizeModule);
                    SessionManager.SetSession(this, SessionManager.SessionName.CurrentAuthorizeScreen, authorizeScreen);
                    return Redirect("~/Default");
                }
                else
                {
                    using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                    {
                        try
                        {
                            user.ConsecutiveFailedLoginCount += 1;
                            user.Persist(base.Context);

                            tran.Commit();
                        }
                        catch (Exception exc)
                        {
                            tran.Rollback();
                            throw exc;
                        }
                    }
                    errorMessage = ModelsRepository.GetLabel("UsernameOrPasswordIsIncorrect");
                }
            }
            else
            {
                errorMessage = ModelsRepository.GetLabel("UsernameOrPasswordIsIncorrect");
            }
            ViewData["ErrorMessage"] = errorMessage;
            return View();
        }

        public ActionResult Logout()
        {
            SessionManager.RemoveSession(this);
            return Redirect("~/Default");
        }

        [UserFilterAuthorizeAttribute]
        public ActionResult Edit(int id, string urlReferrer = "")
        {
            iSISModel.Person person = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Person>()
                                .Where(x => x.ID == id)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .SingleOrDefault();
            ViewData["Person"] = person;

            IList<iSISModel.Role> role = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Role>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .List();
            ViewData["Role"] = role;

            iSISModel.User user = base.Context.PersistenceSession
                                .QueryOver<iSISModel.User>()
                                .Where(x => x.Person.ID == person.ID)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .SingleOrDefault();

            if (user != null)
            {
                iSISModel.UserRole userRole = base.Context.PersistenceSession
                                .QueryOver<iSISModel.UserRole>()
                                .Where(x => x.User.ID == user.ID)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .SingleOrDefault();
                ViewData["RoleID"] = userRole.Role.ID;
            }

            if (string.IsNullOrEmpty(urlReferrer) && Request.UrlReferrer != null)
            {
                urlReferrer = Request.UrlReferrer.ToString();
            }

            ViewData["UrlReferrer"] = urlReferrer;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserFilterAuthorizeAttribute]
        public ActionResult Edit(int id, iSISModel.User user, FormCollection collection)
        {
            string login = collection["Username"];
            string pwd = collection["Password"];
            Int64 roleID = (!string.IsNullOrEmpty(collection["ComboBoxRole_VI"])) ? Int64.Parse(collection["ComboBoxRole_VI"]) : 0;
            string url = collection["UrlReferrer"];

            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            iSISModel.Person person = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Person>()
                                .Where(x => x.ID == id)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .SingleOrDefault();

            iSISModel.Role role = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Role>()
                                .Where(x => x.ID == roleID)
                                .SingleOrDefault();

            IList<iSISModel.User> duplicate = base.Context.PersistenceSession
                                .QueryOver<iSISModel.User>()
                                .Where(x => x.Person.ID != person.ID)
                                .And(x => x.Organization.ID == school.ID)
                                .And(x => x.LoginName == login)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .List();

            if (string.IsNullOrEmpty(login) || role == null || duplicate.Count > 0)
            {
                return Edit(id, url);
            }

            iSISModel.User update = base.Context.PersistenceSession
                                .QueryOver<iSISModel.User>()
                                .Where(x => x.Person.ID == person.ID)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .SingleOrDefault();

            if (update == null && string.IsNullOrEmpty(pwd))
            {
                return Edit(id, url);
            }

            iSISModel.Password password = null;
            if (update == null)
            {
                password = new iSISModel.Password();
                password.EncryptedPassword = iSISModel.Hash.GetHash(pwd, iSISModel.Hash.HashType.SHA512);
                password.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);

                update = new iSISModel.User();
                update.Organization = school;
                update.Person = person;
                update.LoginName = login;
                update.CurrentPassword = password;
                update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                update.LastLoginTimestamp = DateTime.Today;
            }

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    if (!update.CurrentPassword.Match(pwd) && !string.IsNullOrEmpty(pwd))
                    {
                        update.CurrentPassword.EffectivePeriod.To = DateTime.Today;
                        update.CurrentPassword.Persist(base.Context);

                        password = new iSISModel.Password();
                        password.EncryptedPassword = iSISModel.Hash.GetHash(pwd, iSISModel.Hash.HashType.SHA512);
                        password.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);

                        update.CurrentPassword = password;
                    }

                    update.Persist(base.Context);

                    if (password != null)
                    {
                        password.User = update;
                        password.Persist(base.Context);
                    }

                    iSISModel.UserRole userRole = base.Context.PersistenceSession
                                .QueryOver<iSISModel.UserRole>()
                                .Where(x => x.User.ID == update.ID)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .SingleOrDefault();

                    if (userRole == null)
                    {
                        userRole = new iSISModel.UserRole();
                        userRole.Role = role;
                        userRole.User = update;
                        userRole.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                    }
                    else
                    {
                        if (userRole.Role.ID != role.ID)
                        {
                            userRole.EffectivePeriod.To = DateTime.Today;
                            userRole.Persist(base.Context);

                            userRole = new iSISModel.UserRole();
                            userRole.Role = role;
                            userRole.User = update;
                            userRole.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                        }
                    }
                    userRole.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }

            if (!string.IsNullOrEmpty(url))
            {
                return Redirect(url);
            }
            else
            {
                return Edit(id);
            }
        }
    }
}