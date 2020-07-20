using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSIS.Controllers;
using NHibernate;
using TSIS.Filters;
using TSIS.Classes;

namespace TSIS.Areas.Teacher.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class PerformanceMeasurementController : BaseController
    {
        // GET: Teacher/PerformanceMeasurement
        public ActionResult Index(int id)
        {
            iSISModel.CourseSectionStudent courseSectionStudent = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.CourseSectionStudent>()
                                          .Where(x => x.ID == id)
                                          .SingleOrDefault();
            ViewData["ClassLevelSection"] = courseSectionStudent.CourseSection.ClassLevelSection;

            iSISModel.GradingSystem gradingSystem = ((IList<iSISModel.GradingSystem>)CacheManager.GetCache(CacheManager.CacheName.GradingSystem)).FirstOrDefault(x => x.Code == "VeryGood-Fail");
            if (gradingSystem != null)
            {
                IList<iSISModel.DiscreteGrade> performanceMeasurementGrade = base.Context.PersistenceSession
                .QueryOver<iSISModel.DiscreteGrade>()
                .Where(x => x.GradingSystem.ID == gradingSystem.ID)
                .List();

                ViewData["PerformanceMeasurementGrade"] = performanceMeasurementGrade;
            }

            IList<iSISModel.PerformanceMeasurement> performanceMeasurement = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.PerformanceMeasurement>()
                                                .Where(x => x.CourseSection == courseSectionStudent.CourseSection)
                                                .And(x => x.Semester == courseSectionStudent.CourseSection.Semester)
                                                .And(x => x.Student == courseSectionStudent.Student)
                                                .List();
            ViewData["PerformanceMeasurement"] = performanceMeasurement;

            //IList<iSISModel.DesiredOutcome> desiredOutcome = courseSectionStudent.CourseSection.Course.OutcomeCategory.DesiredOutcomes;

            return View(courseSectionStudent);
        }

        [HttpPost]
        public ActionResult Index(int id, FormCollection collection)
        {
            iSISModel.CourseSectionStudent courseSectionStudent = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.CourseSectionStudent>()
                                          .Where(x => x.ID == id)
                                          .SingleOrDefault();

            iSISModel.GradingSystem gradingSystem = ((IList<iSISModel.GradingSystem>)CacheManager.GetCache(CacheManager.CacheName.GradingSystem)).FirstOrDefault(x => x.Code == "VeryGood-Fail");
            IList<iSISModel.DiscreteGrade> discreteGrade = null;
            if (gradingSystem != null)
            {
                discreteGrade = base.Context.PersistenceSession
                .QueryOver<iSISModel.DiscreteGrade>()
                .Where(x => x.GradingSystem.ID == gradingSystem.ID)
                .List();
            }

            IList<iSISModel.DesiredOutcome> desiredOutcome = courseSectionStudent.CourseSection.Course.OutcomeCategory.DesiredOutcomes;

            SavePerformanceMeasurement(collection, desiredOutcome, courseSectionStudent, discreteGrade);

            return RedirectToAction("Index", "CourseSectionPerformance", new { id = courseSectionStudent.CourseSection.ID });
        }

        private void SavePerformanceMeasurement(FormCollection collection, IList<iSISModel.DesiredOutcome> desiredOutcome, iSISModel.CourseSectionStudent courseSectionStudent, IList<iSISModel.DiscreteGrade> discreteGrade)
        {
            foreach (iSISModel.DesiredOutcome item in desiredOutcome)
            {
                if (item is iSISModel.OutcomeCategory)
                {
                    SavePerformanceMeasurement(collection, ((iSISModel.OutcomeCategory)item).DesiredOutcomes, courseSectionStudent, discreteGrade);
                }
                else if (item is iSISModel.ClassLevelOutcome)
                {
                    if (((iSISModel.ClassLevelOutcome)item).ClassLevel.ID == courseSectionStudent.CourseSection.Course.Level.ID)
                    {
                        foreach (iSISModel.PerformanceIndicator pi in ((iSISModel.ClassLevelOutcome)item).PerformanceIndicators)
                        {
                            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                            {
                                try
                                {
                                    string gradeValue = DevExpress.Web.Mvc.EditorExtension.GetValue<string>("PerformanceIndicator_" + pi.ID + "_" + courseSectionStudent.CourseSection.ID);
                                    int gradeID = (!string.IsNullOrEmpty(gradeValue)) ? int.Parse(gradeValue) : 0;
                                    iSISModel.DiscreteGrade grade = discreteGrade.FirstOrDefault(x => x.ID == gradeID);

                                    iSISModel.PerformanceMeasurement performanceMeasurement = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.PerformanceMeasurement>()
                                                .Where(x => x.CourseSection == courseSectionStudent.CourseSection)
                                                .And(x => x.PerformanceIndicator == pi)
                                                .And(x => x.Semester == courseSectionStudent.CourseSection.Semester)
                                                .And(x => x.Student == courseSectionStudent.Student)
                                                .SingleOrDefault();

                                    if (performanceMeasurement == null)
                                    {
                                        performanceMeasurement = new iSISModel.PerformanceMeasurement();
                                        performanceMeasurement.CourseSection = courseSectionStudent.CourseSection;
                                        performanceMeasurement.PerformanceIndicator = pi;
                                        performanceMeasurement.Semester = courseSectionStudent.CourseSection.Semester;
                                        performanceMeasurement.Student = courseSectionStudent.Student;
                                    }
                                    performanceMeasurement.Grade = grade;
                                    performanceMeasurement.Persist(base.Context);

                                    tran.Commit();
                                }
                                catch (Exception exc)
                                {
                                    tran.Rollback();
                                    throw exc;
                                }
                            }
                        }
                    }

                }
            }
        }

        public ActionResult Detail(int id)
        {
            iSISModel.ClassroomStudent classroomStudent = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.ClassroomStudent>()
                                          .Where(x => x.ID == id)
                                          .SingleOrDefault();
            ViewData["ClassroomStudent"] = classroomStudent;
            ViewData["ClassLevelSection"] = classroomStudent.Classroom.ClassLevelSection;

            IList<iSISModel.CourseSectionStudent> courseSectionStudent = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.CourseSectionStudent>()
                                          .Where(x => x.Student == classroomStudent.Student)
                                          .List();

            courseSectionStudent = courseSectionStudent.Where(x => x.CourseSection.ClassLevelSection == classroomStudent.Classroom.ClassLevelSection).ToList();

            IList<iSISModel.DiscreteGrade> discreteGrade = base.Context.PersistenceSession
                                                            .QueryOver<iSISModel.DiscreteGrade>()
                                                            .List();
            ViewData["DiscreteGrade"] = discreteGrade;

            iSISModel.GradingSystem gradingSystem = ((IList<iSISModel.GradingSystem>)CacheManager.GetCache(CacheManager.CacheName.GradingSystem)).FirstOrDefault(x => x.Code == "VeryGood-Fail");
            if (gradingSystem != null)
            {
                IList<iSISModel.DiscreteGrade> performanceMeasurementGrade = base.Context.PersistenceSession
                .QueryOver<iSISModel.DiscreteGrade>()
                .Where(x => x.GradingSystem.ID == gradingSystem.ID)
                .List();

                ViewData["PerformanceMeasurementGrade"] = performanceMeasurementGrade;
            }

            IList<iSISModel.PerformanceMeasurement> performanceMeasurement = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.PerformanceMeasurement>()
                                                .And(x => x.Semester == classroomStudent.Classroom.ClassLevelSection.Semester)
                                                .And(x => x.Student == classroomStudent.Student)
                                                .List();
            ViewData["PerformanceMeasurement"] = performanceMeasurement;

            return View(courseSectionStudent);
        }
    }
}