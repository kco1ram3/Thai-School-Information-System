using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Controllers;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Controllers.Setup
{
    [UserFilterAuthorizeAttribute]
    public class RoleController : BaseController
    {
        #region Role
        // GET: Role
        public ActionResult Index()
        {
            return View(RoleData());
        }

        public ActionResult GridViewRoleData()
        {
            return PartialView("_GridViewRoleData", RoleData());
        }

        [HttpPost]
        public ActionResult GridViewRoleDataAddNewOrUpdate(iSISModel.Role role, FormCollection collection)
        {
            iSISModel.Role update = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Role>()
                                          .Where(x => x.ID == role.ID)
                                          .SingleOrDefault();
            if (update == null)
            {
                update = new iSISModel.Role();
                update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
            }
            if (update.Title == null)
            {
                update.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            }
            else
            {
                update.Title.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "Title"));
            }

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    update.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewRoleData", RoleData());
        }

        [HttpPost]
        public ActionResult GridViewRoleDataDelete(long ID)
        {
            iSISModel.Role role = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.Role>()
                                           .Where(x => x.ID == ID)
                                           .SingleOrDefault();

            role.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    role.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewRoleData", RoleData());
        }

        private IList<iSISModel.Role> RoleData()
        {
            IList<iSISModel.Role> role = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Role>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .List();
            return role;
        }
        #endregion

        #region AuthorizeModule
        public ActionResult AuthorizeModule(int id)
        {
            ViewData["RoleID"] = id;
            iSISModel.Role role = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Role>()
                                          .Where(x => x.ID == id)
                                          .SingleOrDefault();
            ViewData["Role"] = role;
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.AuthorizeModule> authorizeModule = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.AuthorizeModule>()
                                          .Where(x => x.Organization == school)
                                          .And(x => x.Role.ID == id)
                                          .And(x => x.EffectivePeriod.To > DateTime.Today)
                                          .List();
            ViewData["AuthorizeModule"] = authorizeModule;
            return View(ModuleData());
        }

        [HttpPost]
        public ActionResult AuthorizeModule(int id, FormCollection collection)
        {
            iSISModel.Role role = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Role>()
                                          .Where(x => x.ID == id)
                                          .SingleOrDefault();
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);

            foreach (iSISModel.Module module in ModuleData())
            {
                using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        string authorize = collection["Authorize_" + module.ID];
                        bool isAuthorize = false;
                        if (authorize.ToLower().Equals("c"))
                        {
                            isAuthorize = true;
                        }

                        iSISModel.AuthorizeModule authorizeModule = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.AuthorizeModule>()
                                          .Where(x => x.Organization == school)
                                          .And(x => x.Role == role)
                                          .And(x => x.Module == module)
                                          .And(x => x.EffectivePeriod.To > DateTime.Today)
                                          .SingleOrDefault();
                        if (isAuthorize)
                        {
                            if (authorizeModule == null)
                            {
                                authorizeModule = new iSISModel.AuthorizeModule();
                                authorizeModule.Organization = school;
                                authorizeModule.Role = role;
                                authorizeModule.Module = module;
                                authorizeModule.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                            }
                        }
                        else
                        {
                            if (authorizeModule != null)
                            {
                                authorizeModule.EffectivePeriod.To = DateTime.Today;
                            }
                        }

                        if (authorizeModule != null)
                        {
                            authorizeModule.Persist(base.Context);

                            tran.Commit();
                        }
                    }
                    catch (Exception exc)
                    {
                        tran.Rollback();
                        throw exc;
                    }
                }
            }
            if (role.ID == ((iSISModel.Role)SessionManager.GetSession(this, SessionManager.SessionName.CurrentRole)).ID)
            {
                SessionManager.SetSession(this, 
                                          SessionManager.SessionName.CurrentAuthorizeModule,
                                          base.Context.PersistenceSession
                                                      .QueryOver<iSISModel.AuthorizeModule>()
                                                      .Where(x => x.Organization == school)
                                                      .And(x => x.Role == role)
                                                      .And(x => x.EffectivePeriod.To > DateTime.Today)
                                                      .List());
            }
            return AuthorizeModule(id);
        }

        public ActionResult TreeListAuthorizeModule()
        {
            return PartialView("_TreeListAuthorizeModule", ModuleData());
        }

        private IList<iSISModel.Module> ModuleData()
        {
            IList<iSISModel.Module> module = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Module>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .OrderBy(x => x.SeqNo).Asc
                                .List();
            return module;
        }
        #endregion

        #region AuthorizeScreen
        public ActionResult AuthorizeScreen(int id, int moduleID)
        {
            ViewData["RoleID"] = id;
            iSISModel.Role role = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Role>()
                                          .Where(x => x.ID == id)
                                          .SingleOrDefault();
            ViewData["Role"] = role;
            ViewData["ModuleID"] = moduleID;
            iSISModel.Module module = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Module>()
                                          .Where(x => x.ID == moduleID)
                                          .SingleOrDefault();
            ViewData["Module"] = module;
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.AuthorizeScreen> authorizeScreen = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.AuthorizeScreen>()
                                          .Where(x => x.Organization == school)
                                          .And(x => x.Role.ID == id)
                                          .And(x => x.EffectivePeriod.To > DateTime.Today)
                                          .List();
            ViewData["AuthorizeScreen"] = authorizeScreen;
            return View(ScreenData(moduleID));
        }

        [HttpPost]
        public ActionResult AuthorizeScreen(int id, int moduleID, FormCollection collection)
        {
            iSISModel.Role role = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Role>()
                                          .Where(x => x.ID == id)
                                          .SingleOrDefault();
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);

            foreach (iSISModel.Screen screen in ScreenData(moduleID))
            {
                using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        string authorize = collection["Authorize_" + screen.ID];
                        bool isAuthorize = false;
                        if (authorize.ToLower().Equals("c"))
                        {
                            isAuthorize = true;
                        }

                        iSISModel.AuthorizeScreen authorizeScreen = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.AuthorizeScreen>()
                                          .Where(x => x.Organization == school)
                                          .And(x => x.Role == role)
                                          .And(x => x.Screen == screen)
                                          .And(x => x.EffectivePeriod.To > DateTime.Today)
                                          .SingleOrDefault();
                        if (isAuthorize)
                        {
                            if (authorizeScreen == null)
                            {
                                authorizeScreen = new iSISModel.AuthorizeScreen();
                                authorizeScreen.Organization = school;
                                authorizeScreen.Role = role;
                                authorizeScreen.Screen = screen;
                                authorizeScreen.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                            }
                        }
                        else
                        {
                            if (authorizeScreen != null)
                            {
                                authorizeScreen.EffectivePeriod.To = DateTime.Today;
                            }
                        }

                        if (authorizeScreen != null)
                        {
                            authorizeScreen.Persist(base.Context);

                            tran.Commit();
                        }
                    }
                    catch (Exception exc)
                    {
                        tran.Rollback();
                        throw exc;
                    }
                }
            }
            if (role.ID == ((iSISModel.Role)SessionManager.GetSession(this, SessionManager.SessionName.CurrentRole)).ID)
            {
                SessionManager.SetSession(this,
                                          SessionManager.SessionName.CurrentAuthorizeScreen,
                                          base.Context.PersistenceSession
                                                      .QueryOver<iSISModel.AuthorizeScreen>()
                                                      .Where(x => x.Organization == school)
                                                      .And(x => x.Role == role)
                                                      .And(x => x.EffectivePeriod.To > DateTime.Today)
                                                      .List());
            }
            return AuthorizeScreen(id, moduleID);
        }

        public ActionResult TreeListAuthorizeScreen(int moduleID)
        {
            return PartialView("_TreeListAuthorizeScreen", ScreenData(moduleID));
        }

        private IList<iSISModel.Screen> ScreenData(int moduleID)
        {
            IList<iSISModel.Screen> screen = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Screen>()
                                .Where(x => x.Module.ID == moduleID)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .OrderBy(x => x.SeqNo).Asc
                                .List();
            return screen;
        }
        #endregion
    }
}