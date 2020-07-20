using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Controllers.Setup
{
    [UserFilterAuthorizeAttribute]
    public class CourseController : BaseController
    {
        // GET: Course
        public ActionResult Index()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Course> course = (from n in (IList<iSISModel.Course>)CacheManager.GetCache(CacheManager.CacheName.Course)
                                              where n.School.ID == school.ID
                                              select n).ToList();
            return View(course);
        }

        public ActionResult GridViewCourseData()
        {
            iSISModel.CurriculumFramework curriculumFramework = (iSISModel.CurriculumFramework)CacheManager.GetCache(CacheManager.CacheName.CurriculumFramework);
            IList<iSISModel.DesiredOutcome> desiredOutcomes = curriculumFramework.DesiredOutcomes.Where(x => x.EffectivePeriod.To > DateTime.Today && x.Code == "LearningAreas").ToList();
            if (desiredOutcomes.Count > 0) {
                ViewData["DesiredOutcome"] = ((iSISModel.OutcomeCategory)desiredOutcomes[0]).DesiredOutcomes;
            }

            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Course> course = (from n in (IList<iSISModel.Course>)CacheManager.GetCache(CacheManager.CacheName.Course)
                                              where n.School.ID == school.ID
                                              select n).ToList();
            return PartialView("_GridViewCourseData", course);
        }

        [HttpPost]
        public ActionResult GridViewCourseDataAddNew(iSISModel.Course course, FormCollection collection)
        {
            Int64 classLevelID = (!string.IsNullOrEmpty(collection["ComboBoxLevelNo_VI"])) ? Int64.Parse(collection["ComboBoxLevelNo_VI"]) : 0;
            //int gradingSystemID = (!string.IsNullOrEmpty(collection["ComboBoxGradingSystem_VI"])) ? int.Parse(collection["ComboBoxGradingSystem_VI"]) : 0;
            long outcomeCategoryID = (!string.IsNullOrEmpty(collection["ComboBoxOutcomeCategory_VI"])) ? int.Parse(collection["ComboBoxOutcomeCategory_VI"]) : 0;

            iSISModel.CurriculumFramework curriculumFramework = (iSISModel.CurriculumFramework)CacheManager.GetCache(CacheManager.CacheName.CurriculumFramework);
            IList<iSISModel.DesiredOutcome> desiredOutcomes = curriculumFramework.DesiredOutcomes.Where(x => x.EffectivePeriod.To > DateTime.Today && x.Code == "LearningAreas").ToList();
            iSISModel.OutcomeCategory outcomeCategory = null;
            if (desiredOutcomes.Count > 0)
            {
                outcomeCategory = (iSISModel.OutcomeCategory)(((iSISModel.OutcomeCategory)desiredOutcomes[0]).DesiredOutcomes).SingleOrDefault(x => x.ID == outcomeCategoryID);
            }

            course.School = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            course.Level = ModelsRepository.GetClassLevelByID(classLevelID);
            course.OutcomeCategory = outcomeCategory;
            if (outcomeCategory != null)
            {
                course.GradingSystem = outcomeCategory.DefaultGradingSystem;
            }
            else
            {
                course.GradingSystem = null;
            }
            //course.GradingSystem = ModelsRepository.GetGradingSystemByID(gradingSystemID);
            course.CourseNo = ModelsRepository.GetTextBoxMultiLanguages(collection, "CourseNo");
            course.Description = ModelsRepository.GetTextBoxMultiLanguages(collection, "Description");
            course.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            course.ShortTitle = ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle");
            course.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    course.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewCourseData", CourseData());
        }

        [HttpPost]
        public ActionResult GridViewCourseDataUpdate(iSISModel.Course course, FormCollection collection)
        {
            iSISModel.Course update = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Course>()
                                          .Where(x => x.ID == course.ID)
                                          .SingleOrDefault();

            Int64 classLevelID = (!string.IsNullOrEmpty(collection["ComboBoxLevelNo_VI"])) ? Int64.Parse(collection["ComboBoxLevelNo_VI"]) : 0;
            //int gradingSystemID = (!string.IsNullOrEmpty(collection["ComboBoxGradingSystem_VI"])) ? int.Parse(collection["ComboBoxGradingSystem_VI"]) : 0;
            long outcomeCategoryID = (!string.IsNullOrEmpty(collection["ComboBoxOutcomeCategory_VI"])) ? int.Parse(collection["ComboBoxOutcomeCategory_VI"]) : 0;

            iSISModel.CurriculumFramework curriculumFramework = (iSISModel.CurriculumFramework)CacheManager.GetCache(CacheManager.CacheName.CurriculumFramework);
            IList<iSISModel.DesiredOutcome> desiredOutcomes = curriculumFramework.DesiredOutcomes.Where(x => x.EffectivePeriod.To > DateTime.Today && x.Code == "LearningAreas").ToList();
            iSISModel.OutcomeCategory outcomeCategory = null;
            if (desiredOutcomes.Count > 0)
            {
                outcomeCategory = (iSISModel.OutcomeCategory)(((iSISModel.OutcomeCategory)desiredOutcomes[0]).DesiredOutcomes).SingleOrDefault(x => x.ID == outcomeCategoryID);
            }

            update.Level = ModelsRepository.GetClassLevelByID(classLevelID);
            update.OutcomeCategory = outcomeCategory;
            if (outcomeCategory != null)
            {
                update.GradingSystem = outcomeCategory.DefaultGradingSystem;
            }
            else
            {
                update.GradingSystem = null;
            }
            //update.GradingSystem = ModelsRepository.GetGradingSystemByID(gradingSystemID);
            update.CreditHours = course.CreditHours;
            update.HoursPerSemester = course.HoursPerSemester;
            if (update.CourseNo == null)
            {
                update.CourseNo = ModelsRepository.GetTextBoxMultiLanguages(collection, "CourseNo");
            }
            else
            {
                update.CourseNo.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "CourseNo"));
            }
            if (update.Description == null)
            {
                update.Description = ModelsRepository.GetTextBoxMultiLanguages(collection, "Description");
            }
            else
            {
                update.Description.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "Description"));
            }
            if (update.Title == null)
            {
                update.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            }
            else
            {
                update.Title.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "Title"));
            }
            if (update.ShortTitle == null)
            {
                update.ShortTitle = ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle");
            }
            else
            {
                update.ShortTitle.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle"));
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
            return PartialView("_GridViewCourseData", CourseData());
        }

        [HttpPost]
        public ActionResult GridViewCourseDataDelete(long ID)
        {
            iSISModel.Course course = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Course>()
                                          .Where(x => x.ID == ID)
                                          .SingleOrDefault();

            course.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    course.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewCourseData", CourseData());
        }

        private IList<iSISModel.Course> CourseData()
        {
            iSISModel.CurriculumFramework curriculumFramework = (iSISModel.CurriculumFramework)CacheManager.GetCache(CacheManager.CacheName.CurriculumFramework);
            IList<iSISModel.DesiredOutcome> desiredOutcomes = curriculumFramework.DesiredOutcomes.Where(x => x.EffectivePeriod.To > DateTime.Today && x.Code == "LearningAreas").ToList();
            if (desiredOutcomes.Count > 0)
            {
                ViewData["DesiredOutcome"] = ((iSISModel.OutcomeCategory)desiredOutcomes[0]).DesiredOutcomes;
            }

            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Course> course = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Course>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.Course, course);

            return course.Where(x => x.School.ID == school.ID).ToList();
        }
    }
}