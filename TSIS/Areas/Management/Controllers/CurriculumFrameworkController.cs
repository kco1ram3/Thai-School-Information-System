using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSIS.Controllers;
using TSIS.Filters;
using TSIS.Classes;
using TSIS.Models;
using iSISModel;
using NHibernate;

namespace TSIS.Areas.Management.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class CurriculumFrameworkController : BaseController
    {
        // GET: Management/CurriculumFramework
        public ActionResult Index()
        {
            return View(getCurriculumFrameworks());
        }

        public ActionResult CurriculumFramworkPartial()
        {
            return PartialView("_GridViewCurriculumFramework", getCurriculumFrameworks());
        }

        public ActionResult CurriculumFramworkPartialAddNew(iSISModel.CurriculumFramework curriculumFramework, FormCollection collection)
        {
            DateTime EffectivePeriodFrom = (!string.IsNullOrEmpty(collection["EffectivePeriodFrom"])) ? DateTime.Parse(collection["EffectivePeriodFrom"]) : DateTimeRange.MaxDate;
            DateTime EffectivePeriodTo = (!string.IsNullOrEmpty(collection["EffectivePeriodTo"])) ? DateTime.Parse(collection["EffectivePeriodTo"]) : DateTimeRange.MaxDate;

            curriculumFramework.Code = (!string.IsNullOrEmpty(collection["Code"])) ? collection["Code"].ToString() : string.Empty;
            curriculumFramework.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            curriculumFramework.ShortTitle = ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle");
            curriculumFramework.EffectivePeriod = new iSISModel.DateTimeRange(EffectivePeriodFrom, EffectivePeriodTo);

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    curriculumFramework.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewCurriculumFramework", getCurriculumFrameworks());
        }

        public ActionResult CurriculumFramworkPartialUpdate(iSISModel.CurriculumFramework CurriculumFramework, FormCollection collection)
        {
            iSISModel.CurriculumFramework update = base.Context.PersistenceSession
                                                      .QueryOver<iSISModel.CurriculumFramework>()
                                                      .Where(x => x.ID == CurriculumFramework.ID)
                                                      .SingleOrDefault();

            DateTime EffectivePeriodFrom = (!string.IsNullOrEmpty(collection["EffectivePeriodFrom"])) ? DateTime.Parse(collection["EffectivePeriodFrom"]) : DateTimeRange.MaxDate;
            DateTime EffectivePeriodTo = (!string.IsNullOrEmpty(collection["EffectivePeriodTo"])) ? DateTime.Parse(collection["EffectivePeriodTo"]) : DateTimeRange.MaxDate;

            update.Code = (!string.IsNullOrEmpty(collection["Code"])) ? collection["Code"].ToString() : string.Empty;
            update.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            update.ShortTitle = ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle");
            update.EffectivePeriod = new iSISModel.DateTimeRange(EffectivePeriodFrom, EffectivePeriodTo);

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
            return PartialView("_GridViewCurriculumFramework", getCurriculumFrameworks());
        }

        public ActionResult CurriculumFramworkPartialDelete(iSISModel.CurriculumFramework CurriculumFramework, FormCollection collection)
        {
            iSISModel.CurriculumFramework delete = base.Context.PersistenceSession
                                            .QueryOver<iSISModel.CurriculumFramework>()
                                            .Where(c => c.ID == CurriculumFramework.ID)
                                            .SingleOrDefault();

            delete.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    delete.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewCurriculumFramework", getCurriculumFrameworks());
        }
        private IList<iSISModel.CurriculumFramework> getCurriculumFrameworks()
        {
            return base.Context.PersistenceSession
                    .QueryOver<iSISModel.CurriculumFramework>()
                    .Where(c => c.EffectivePeriod.To > DateTime.Today)
                    .List();
        }
    }
}