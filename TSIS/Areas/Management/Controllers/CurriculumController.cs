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
    public class CurriculumController : BaseController
    {
        // GET: Management/Curriculum
        public ActionResult Index()
        {
            return View(getCurriculums());
        }

        public ActionResult CurriculumPartial()
        {
            return PartialView("_GridViewCurriculum", getCurriculums());
        }

        public ActionResult CurriculumPartialAddNew(iSISModel.Curriculum curriculum, FormCollection collection)
        {
            DateTime EffectivePeriodFrom = (!string.IsNullOrEmpty(collection["EffectivePeriodFrom"])) ? DateTime.Parse(collection["EffectivePeriodFrom"]) : DateTimeRange.MaxDate;
            DateTime EffectivePeriodTo = (!string.IsNullOrEmpty(collection["EffectivePeriodTo"])) ? DateTime.Parse(collection["EffectivePeriodTo"]) : DateTimeRange.MaxDate;

            Int64 CurriculumFrameworkID = (!string.IsNullOrEmpty(collection["ComboBoxCurriculumFramework_VI"])) ? Int64.Parse(collection["ComboBoxCurriculumFramework_VI"]) : 0;
            iSISModel.CurriculumFramework curriculumFramework = base.Context.PersistenceSession
                                                                    .QueryOver<iSISModel.CurriculumFramework>()
                                                                    .Where(c => c.ID == CurriculumFrameworkID)
                                                                    .SingleOrDefault();
            Int64 startingClassLevelNo = (!string.IsNullOrEmpty(collection["ComboBoxStartingClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxStartingClassLevel_VI"]) : 0;
            iSISModel.ClassLevel StartingClassLevel = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevel>()
                                                .Where(c => c.LevelNo == startingClassLevelNo)
                                                .SingleOrDefault();
            Int64 endingClassLevelNo = (!string.IsNullOrEmpty(collection["ComboBoxEndingClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxEndingClassLevel_VI"]) : 0;
            iSISModel.ClassLevel EndingClassLevel = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevel>()
                                                .Where(c => c.LevelNo == endingClassLevelNo)
                                                .SingleOrDefault();

            curriculum.CurriculumFramework = curriculumFramework;
            curriculum.School = Context.CurrentSchool;
            curriculum.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            curriculum.ShortTitle = ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle");
            curriculum.StartingClassLevel = StartingClassLevel;
            curriculum.EndingClassLevel = EndingClassLevel;
            curriculum.EffectivePeriod = new iSISModel.DateTimeRange(EffectivePeriodFrom, EffectivePeriodTo);

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    curriculum.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewCurriculum", getCurriculums());
        }

        public ActionResult CurriculumPartialUpdate(iSISModel.Curriculum curriculum, FormCollection collection)
        {
            iSISModel.Curriculum update = base.Context.PersistenceSession
                                                      .QueryOver<iSISModel.Curriculum>()
                                                      .Where(x => x.ID == curriculum.ID)
                                                      .SingleOrDefault();

            DateTime EffectivePeriodFrom = (!string.IsNullOrEmpty(collection["EffectivePeriodFrom"])) ? DateTime.Parse(collection["EffectivePeriodFrom"]) : DateTimeRange.MaxDate;
            DateTime EffectivePeriodTo = (!string.IsNullOrEmpty(collection["EffectivePeriodTo"])) ? DateTime.Parse(collection["EffectivePeriodTo"]) : DateTimeRange.MaxDate;

            Int64 CurriculumFrameworkID = (!string.IsNullOrEmpty(collection["ComboBoxCurriculumFramework_VI"])) ? Int64.Parse(collection["ComboBoxCurriculumFramework_VI"]) : 0;
            iSISModel.CurriculumFramework curriculumFramework = base.Context.PersistenceSession
                                                                    .QueryOver<iSISModel.CurriculumFramework>()
                                                                    .Where(c => c.ID == CurriculumFrameworkID)
                                                                    .SingleOrDefault();
            Int64 startingClassLevelNo = (!string.IsNullOrEmpty(collection["ComboBoxStartingClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxStartingClassLevel_VI"]) : 0;
            iSISModel.ClassLevel StartingClassLevel = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevel>()
                                                .Where(c => c.LevelNo == startingClassLevelNo)
                                                .SingleOrDefault();
            Int64 endingClassLevelNo = (!string.IsNullOrEmpty(collection["ComboBoxEndingClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxEndingClassLevel_VI"]) : 0;
            iSISModel.ClassLevel EndingClassLevel = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevel>()
                                                .Where(c => c.LevelNo == endingClassLevelNo)
                                                .SingleOrDefault();

            update.CurriculumFramework = curriculumFramework;
            update.School = Context.CurrentSchool;
            update.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            update.ShortTitle = ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle");
            update.StartingClassLevel = StartingClassLevel;
            update.EndingClassLevel = EndingClassLevel;
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
            return PartialView("_GridViewCurriculum", getCurriculums());
        }

        public ActionResult CurriculumPartialDelete(iSISModel.Curriculum curriculum, FormCollection collection)
        {
            iSISModel.Curriculum delete = base.Context.PersistenceSession
                                            .QueryOver<iSISModel.Curriculum>()
                                            .Where(c => c.ID == curriculum.ID)
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
            return PartialView("_GridViewCurriculum", getCurriculums());
        }

        private IList<iSISModel.Curriculum> getCurriculums()
        {
            ViewData["ClassLevel"] = CacheManager.GetCache(CacheManager.CacheName.ClassLevel);
            ViewData["CurriculumFramework"] = getCurriculumFrameworks();

            iSISModel.School school = Context.CurrentSchool;

            return base.Context.PersistenceSession
                    .QueryOver<iSISModel.Curriculum>()
                    .Where(c => c.School == school)
                    .And(c => c.EffectivePeriod.To > DateTime.Today)
                    .OrderBy(c => c.CurriculumFramework.ID).Asc
                    .OrderBy(c => c.StartingClassLevel.ID).Asc
                    .List();
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