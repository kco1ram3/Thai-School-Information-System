using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using TSIS.Models;
using TSIS.Filters;
using TSIS.Classes;

namespace TSIS.Controllers.Setup
{
    [UserFilterAuthorizeAttribute]
    public class LanguageController : BaseController
    {
        // GET: Language
        public ActionResult Index()
        {
            return View((IList<iSISModel.Language>)CacheManager.GetCache(CacheManager.CacheName.Language));
        }

        public ActionResult GridViewLanguageSetup()
        {
            return PartialView("_GridViewLanguageSetup", (IList<iSISModel.Language>)CacheManager.GetCache(CacheManager.CacheName.Language));
        }

        [HttpPost]
        public ActionResult GridViewLanguageSetupAddNewOrUpdate(iSISModel.Language language, FormCollection collection)
        {
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    language.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewLanguageSetup", LanguageSetup());
        }

        [HttpPost]
        public ActionResult GridViewLanguageSetupDelete(string Code)
        {
            iSISModel.Language language = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.Language>()
                                           .Where(x => x.Code == Code)
                                           .SingleOrDefault();
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    base.Context.PersistenceSession.Delete(language);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewLanguageSetup", LanguageSetup());
        }

        private IList<iSISModel.Language> LanguageSetup()
        {
            IList<iSISModel.Language> language = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Language>()
                                .OrderBy(i => i.SeqNo).Asc
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.Language, language);

            return language;
        }

        public ActionResult Labels()
        {
            IList<iSISModel.HierarchicalCategory> label = (IList<iSISModel.HierarchicalCategory>)CacheManager.GetCache(CacheManager.CacheName.Label);
            if (label.Count > 0)
            {
                return View(label[0].Children);
            }
            else
            {
                return View(label);
            }
        }

        public ActionResult GridViewLabelSetup()
        {
            IList<iSISModel.HierarchicalCategory> label = (IList<iSISModel.HierarchicalCategory>)CacheManager.GetCache(CacheManager.CacheName.Label);
            if (label.Count > 0)
            {
                return PartialView("_GridViewLabelSetup", label[0].Children);
            }
            else
            {
                return PartialView("_GridViewLabelSetup", label);
            }
        }

        [HttpPost]
        public ActionResult GridViewLabelSetupAddNewOrUpdate(iSISModel.HierarchicalCategory label, FormCollection collection)
        {
            iSISModel.HierarchicalCategory update = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.HierarchicalCategory>()
                                           .Where(x => x.ID == label.ID)
                                           .SingleOrDefault();
            if (update == null)
            {
                update = new iSISModel.HierarchicalCategory();
                IList<iSISModel.HierarchicalCategory> parent = (IList<iSISModel.HierarchicalCategory>)CacheManager.GetCache(CacheManager.CacheName.Label);
                if (parent.Count > 0)
                {
                    update.Parent = parent[0];
                }
            }
            update.Code = label.Code;
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
            return PartialView("_GridViewLabelSetup", LabelSetup());
        }

        [HttpPost]
        public ActionResult GridViewLabelSetupDelete(int ID)
        {
            iSISModel.HierarchicalCategory label = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.HierarchicalCategory>()
                                           .Where(x => x.ID == ID)
                                           .SingleOrDefault();
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    base.Context.PersistenceSession.Delete(label);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewLabelSetup", LabelSetup());
        }

        private IList<iSISModel.HierarchicalCategory> LabelSetup()
        {
            IList<iSISModel.HierarchicalCategory> label = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "Label").And(l => l.Parent == null)
                                               .List();

            CacheManager.SetCache(CacheManager.CacheName.Label, label);

            if (label.Count > 0)
            {
                return label[0].Children;
            }
            else
            {
                return label;
            }
        }
    }
}