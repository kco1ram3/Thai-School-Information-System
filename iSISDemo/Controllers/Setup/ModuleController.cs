using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Controllers;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;

namespace iSISDemo.Controllers.Setup
{
    [UserFilterAuthorizeAttribute]
    public class ModuleController : BaseController
    {
        #region Module
        // GET: Module
        public ActionResult Index()
        {
            return View(ModuleData());
        }

        public ActionResult TreeListModuleData()
        {
            return PartialView("_TreeListModuleData", ModuleData());
        }

        [HttpPost]
        public ActionResult TreeListModuleDataAddNewOrUpdate(iSISModel.Module module, FormCollection collection)
        {
            iSISModel.Module update = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Module>()
                                          .Where(x => x.ID == module.ID)
                                          .SingleOrDefault();
            if (update == null)
            {
                update = new iSISModel.Module();
                update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
            }
            update.SeqNo = module.SeqNo;
            update.NavigateUrl = module.NavigateUrl;
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
            return PartialView("_TreeListModuleData", ModuleData());
        }

        [HttpPost]
        public ActionResult TreeListModuleDataDelete(long ID)
        {
            iSISModel.Module module = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Module>()
                                          .Where(x => x.ID == ID)
                                          .SingleOrDefault();

            module.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    module.Persist(base.Context);
                    foreach (iSISModel.Module i in module.Children)
                    {
                        i.EffectivePeriod.To = DateTime.Today;
                        i.Persist(base.Context);
                        DeleteModuleData(i.Children);
                    }

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_TreeListModuleData", ModuleData());
        }

        [HttpPost]
        public ActionResult TreeListModuleDataMove(long ID, iSISModel.Module parent)
        {
            iSISModel.Module module = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Module>()
                                          .Where(x => x.ID == ID)
                                          .SingleOrDefault();

            parent = base.Context.PersistenceSession
                                 .QueryOver<iSISModel.Module>()
                                 .Where(x => x.ID == parent.ID)
                                 .SingleOrDefault();

            module.Parent = parent;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    module.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_TreeListModuleData", ModuleData());
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

        private void DeleteModuleData(IList<iSISModel.Module> module)
        {
            foreach (iSISModel.Module i in module)
            {
                i.EffectivePeriod.To = DateTime.Today;
                i.Persist(base.Context);
                DeleteModuleData(i.Children);
            }
        }
        #endregion

        #region Screen
        public ActionResult Screen(int id)
        {
            ViewData["ModuleID"] = id;
            iSISModel.Module module = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Module>()
                                          .Where(x => x.ID == id)
                                          .SingleOrDefault();
            ViewData["Module"] = module;
            return View(ScreenData(id));
        }

        public ActionResult TreeListScreenData(int moduleID)
        {
            ViewData["ModuleID"] = moduleID;
            return PartialView("_TreeListScreenData", ScreenData(moduleID));
        }

        [HttpPost]
        public ActionResult TreeListScreenDataAddNewOrUpdate(int moduleID, iSISModel.Screen screen, FormCollection collection)
        {
            ViewData["ModuleID"] = moduleID;
            iSISModel.Screen update = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Screen>()
                                          .Where(x => x.ID == screen.ID)
                                          .SingleOrDefault();
            if (update == null)
            {
                iSISModel.Module module = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Module>()
                                          .Where(x => x.ID == moduleID)
                                          .SingleOrDefault();

                update = new iSISModel.Screen();
                update.Module = module;
                update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
            }
            update.SeqNo = screen.SeqNo;
            update.NavigateUrl = screen.NavigateUrl;
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
            return PartialView("_TreeListScreenData", ScreenData(moduleID));
        }

        [HttpPost]
        public ActionResult TreeListScreenDataDelete(int moduleID, long ID)
        {
            ViewData["ModuleID"] = moduleID;
            iSISModel.Screen screen = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Screen>()
                                          .Where(x => x.ID == ID)
                                          .SingleOrDefault();

            screen.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    screen.Persist(base.Context);
                    foreach (iSISModel.Screen i in screen.Children)
                    {
                        i.EffectivePeriod.To = DateTime.Today;
                        i.Persist(base.Context);
                        DeleteScreenData(i.Children);
                    }

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_TreeListScreenData", ScreenData(moduleID));
        }

        [HttpPost]
        public ActionResult TreeListScreenDataMove(int moduleID, long ID, iSISModel.Screen parent)
        {
            ViewData["ModuleID"] = moduleID;
            iSISModel.Screen screen = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Screen>()
                                          .Where(x => x.ID == ID)
                                          .SingleOrDefault();

            parent = base.Context.PersistenceSession
                                 .QueryOver<iSISModel.Screen>()
                                 .Where(x => x.ID == parent.ID)
                                 .SingleOrDefault();

            screen.Parent = parent;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    screen.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_TreeListScreenData", ScreenData(moduleID));
        }

        private IList<iSISModel.Screen> ScreenData(int id)
        {
            IList<iSISModel.Screen> screen = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Screen>()
                                .Where(x => x.Module.ID == id)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .OrderBy(x => x.SeqNo).Asc
                                .List();
            return screen;
        }

        private void DeleteScreenData(IList<iSISModel.Screen> screen)
        {
            foreach (iSISModel.Screen i in screen)
            {
                i.EffectivePeriod.To = DateTime.Today;
                i.Persist(base.Context);
                DeleteScreenData(i.Children);
            }
        }
        #endregion
    }
}