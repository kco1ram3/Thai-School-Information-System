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
    public class CourseSectionPerformanceController : BaseController
    {
        // GET: Teacher/CourseSectionPerformance
        public ActionResult Index(int id)
        {
            ViewData["courseSectionID"] = id;
            ViewData["CourseSection"] = getCourseSection(id);
            ViewData["CourseSectionAppraisal"] = getCourseSectionAppraisalList(id);
            ViewData["CourseSectionPerformance"] = getCourseSectionPerformanceList(id);
            ViewData["DiscreteGrade"] = getDiscreteGradeList(id);

            return View(getCourseSectionStudentList(id));
        }

        [HttpPost]
        public ActionResult Index(int id, FormCollection collection)
        {
            IList<iSISModel.CourseSectionStudent> courseSectionStudent = getCourseSectionStudentList(id);
            IList<iSISModel.CourseSectionAppraisal> courseSectionAppraisal = getCourseSectionAppraisalList(id);
            IList<iSISModel.DiscreteGrade> discreteGrade = getDiscreteGradeList(id);

            int courseSectionAppraisalID = (!string.IsNullOrEmpty(collection["courseSectionAppraisalID"])) ? int.Parse(collection["courseSectionAppraisalID"]) : 0;
            courseSectionAppraisal = courseSectionAppraisal.Where(x => x.ID == courseSectionAppraisalID).ToList();

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    foreach (iSISModel.CourseSectionStudent item1 in courseSectionStudent)
                    {
                        foreach (iSISModel.CourseSectionAppraisal item2 in courseSectionAppraisal)
                        {
                            //DateTime appraisalDate = (!string.IsNullOrEmpty(collection[item2.ID + "_AppraisalDate"])) ? DateTime.Parse(collection[item2.ID + "_AppraisalDate"]) : DateTime.Today;
                            //float score = (!string.IsNullOrEmpty(collection["score_" + item1.ID + "_" + item2.ID])) ? float.Parse(collection["score_" + item1.ID + "_" + item2.ID]) : 0;
                            float? score = DevExpress.Web.Mvc.EditorExtension.GetValue<float?>("score_" + item1.ID + "_" + item2.ID);

                            iSISModel.CourseSectionPerformance courseSectionPerformance = base.Context.PersistenceSession
                                .QueryOver<iSISModel.CourseSectionPerformance>()
                                .Where(x => x.CourseSectionStudent == item1)
                                .And(x => x.CourseSectionAppraisal == item2)
                                .SingleOrDefault();

                            if (courseSectionPerformance == null)
                            {
                                courseSectionPerformance = new iSISModel.CourseSectionPerformance();
                            }
                            courseSectionPerformance.CourseSectionStudent = item1;
                            courseSectionPerformance.CourseSectionAppraisal = item2;
                            courseSectionPerformance.AppraisalDate = item2.AppraisalDate; //appraisalDate
                            if (score != null)
                            {
                                courseSectionPerformance.Score = (float)score;
                            }
                            courseSectionPerformance.Persist(base.Context);
                        }

                        if (courseSectionAppraisalID == -99 || courseSectionAppraisalID == -999)
                        {
                            int? gradeID = DevExpress.Web.Mvc.EditorExtension.GetValue<int?>(item1.ID + "_Grade");
                            if (gradeID != null)
                            {
                                iSISModel.DiscreteGrade grade = discreteGrade.FirstOrDefault(x => x.ID == gradeID);

                                item1.Grade = grade;
                                item1.GradePoint = grade != null ? grade.Point : 0;
                            }
                        }
                        item1.Persist(base.Context);
                    }

                    foreach (iSISModel.CourseSectionAppraisal item in courseSectionAppraisal)
                    {
                        IList<iSISModel.CourseSectionPerformance> courseSectionPerformance = base.Context.PersistenceSession
                                .QueryOver<iSISModel.CourseSectionPerformance>()
                                .And(x => x.CourseSectionAppraisal == item)
                                .List();

                        item.MinScore = courseSectionPerformance.Min(x => x.Score);
                        item.MaxScore = courseSectionPerformance.Max(x => x.Score);
                        item.AverageScore = courseSectionPerformance.Average(x => x.Score);
                        item.Persist(base.Context);
                    }

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }

            ViewData["courseSectionID"] = id;
            ViewData["CourseSection"] = getCourseSection(id);
            ViewData["CourseSectionAppraisal"] = getCourseSectionAppraisalList(id);
            ViewData["CourseSectionPerformance"] = getCourseSectionPerformanceList(id);
            ViewData["DiscreteGrade"] = getDiscreteGradeList(id);

            return View(getCourseSectionStudentList(id));
        }

        public ActionResult Detail(int id, int courseSectionID)
        {
            ViewData["courseSectionID"] = courseSectionID;
            ViewData["CourseSection"] = getCourseSection(courseSectionID);
            ViewData["CourseSectionAppraisal"] = getCourseSectionAppraisalList(courseSectionID);
            ViewData["CourseSectionPerformance"] = getCourseSectionPerformanceList(courseSectionID).Where(x => x.CourseSectionStudent.ID == id).ToList();
            ViewData["DiscreteGrade"] = getDiscreteGradeList(courseSectionID);

            return View(getCourseSectionStudentList(courseSectionID).FirstOrDefault(x => x.ID == id));
        }

        [HttpPost]
        public ActionResult Detail(int id, int courseSectionID, FormCollection collection)
        {
            iSISModel.CourseSectionStudent courseSectionStudent = getCourseSectionStudentList(courseSectionID).FirstOrDefault(x => x.ID == id);
            IList<iSISModel.CourseSectionAppraisal> courseSectionAppraisal = getCourseSectionAppraisalList(courseSectionID);
            IList<iSISModel.DiscreteGrade> discreteGrade = getDiscreteGradeList(courseSectionID);
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    foreach (iSISModel.CourseSectionAppraisal item in courseSectionAppraisal)
                    {
                        DateTime appraisalDate = (!string.IsNullOrEmpty(collection[item.ID + "_AppraisalDate"])) ? DateTime.Parse(collection[item.ID + "_AppraisalDate"]) : DateTime.Today;
                        float score = (!string.IsNullOrEmpty(collection["score_" + item.ID])) ? float.Parse(collection["score_" + item.ID]) : 0;

                        iSISModel.CourseSectionPerformance courseSectionPerformance = base.Context.PersistenceSession
                            .QueryOver<iSISModel.CourseSectionPerformance>()
                            .Where(x => x.CourseSectionStudent.ID == id)
                            .And(x => x.CourseSectionAppraisal == item)
                            .SingleOrDefault();

                        if (courseSectionPerformance == null)
                        {
                            courseSectionPerformance = new iSISModel.CourseSectionPerformance();
                            courseSectionPerformance.CourseSectionStudent = courseSectionStudent;
                        }
                        courseSectionPerformance.CourseSectionAppraisal = item;
                        courseSectionPerformance.AppraisalDate = appraisalDate;
                        courseSectionPerformance.Score = score;
                        courseSectionPerformance.Persist(base.Context);
                    }
                    int gradeID = (!string.IsNullOrEmpty(collection["Grade_VI"])) ? int.Parse(collection["Grade_VI"]) : 0;
                    iSISModel.DiscreteGrade grade = discreteGrade.FirstOrDefault(x => x.ID == gradeID);

                    courseSectionStudent.Grade = grade;
                    courseSectionStudent.GradePoint = grade != null ? grade.Point : 0;
                    courseSectionStudent.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }

            return RedirectToAction("Index", new { id = courseSectionID });
        }

        public ActionResult GridViewCourseSectionPerformance(int courseSectionID)
        {
            int courseSectionAppraisalID = (!string.IsNullOrEmpty(Request.Params["courseSectionAppraisalID"])) ? int.Parse(Request.Params["courseSectionAppraisalID"]) : 0;
            ViewData["courseSectionAppraisalID"] = courseSectionAppraisalID;
            ViewData["courseSectionID"] = courseSectionID;
            ViewData["CourseSectionAppraisal"] = getCourseSectionAppraisalList(courseSectionID);
            ViewData["CourseSectionPerformance"] = getCourseSectionPerformanceList(courseSectionID);
            ViewData["DiscreteGrade"] = getDiscreteGradeList(courseSectionID);
            if (courseSectionAppraisalID == -999)
            {
                ViewData["AutomaticGrading"] = getAutomaticGrading(courseSectionID);
            }
            return PartialView("_GridViewCourseSectionPerformance", getCourseSectionStudentList(courseSectionID));
        }

        private iSISModel.CourseSection getCourseSection(int courseSectionID)
        {
            iSISModel.CourseSection courseSection = base.Context.PersistenceSession
                .QueryOver<iSISModel.CourseSection>()
                .Where(x => x.ID == courseSectionID)
                .SingleOrDefault();

            return courseSection;
        }

        private IList<iSISModel.CourseSectionStudent> getCourseSectionStudentList(int courseSectionID)
        {
            IList<iSISModel.CourseSectionStudent> courseSectionStudent = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.CourseSectionStudent>()
                                               .Where(x => x.CourseSection.ID == courseSectionID)
                                               .And(x => x.EffectivePeriod.To > DateTime.Today)
                                               .List();
            return courseSectionStudent;
        }

        private IList<iSISModel.CourseSectionAppraisal> getCourseSectionAppraisalList(int courseSectionID)
        {
            IList<iSISModel.CourseSectionAppraisal> courseSectionAppraisal = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.CourseSectionAppraisal>()
                                               .Where(x => x.CourseSection.ID == courseSectionID)
                                               .And(x => x.EffectivePeriod.To > DateTime.Today)
                                               .OrderBy(x => x.SeqNo).Asc
                                               .List();
            return courseSectionAppraisal;
        }

        private IList<iSISModel.CourseSectionPerformance> getCourseSectionPerformanceList(int courseSectionID)
        {
            IList<iSISModel.CourseSectionPerformance> courseSectionPerformance = Context.PersistenceSession
                .QueryOver<iSISModel.CourseSectionPerformance>()
                .List();

            return courseSectionPerformance.Where(x => x.CourseSectionAppraisal.CourseSection.ID == courseSectionID && x.CourseSectionAppraisal.EffectivePeriod.To > DateTime.Today).ToList();
        }

        private IList<iSISModel.DiscreteGrade> getDiscreteGradeList(int courseSectionID)
        {
            IList<iSISModel.DiscreteGrade> discreteGrade = Context.PersistenceSession
                .QueryOver<iSISModel.DiscreteGrade>()
                .Where(x => x.GradingSystem.ID == getCourseSection(courseSectionID).Course.GradingSystem.ID)
                .List();

            return discreteGrade;
        }

        private Dictionary<long, long> getAutomaticGrading(int courseSectionID)
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.AutomaticGrading> automaticGrading = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.AutomaticGrading>()
                                          .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                          .And(x => x.School == school)
                                          .List();

            automaticGrading = automaticGrading.Where(x => x.DiscreteGrade.GradingSystem.ID == getCourseSection(courseSectionID).Course.GradingSystem.ID).ToList();

            IList<iSISModel.CourseSectionPerformance> performance = getCourseSectionPerformanceList(courseSectionID);
            float fullScore = getCourseSectionAppraisalList(courseSectionID).Sum(x => x.PerfectScore);
            Dictionary<long, long> result = new Dictionary<long, long>();

            foreach (iSISModel.CourseSectionStudent item in getCourseSectionStudentList(courseSectionID))
            {
                try
                {
                    int percentage = int.Parse(Math.Round((performance.Where(x => x.CourseSectionStudent == item).Sum(x => x.Score) * 100) / fullScore, 0).ToString());
                    IList<iSISModel.AutomaticGrading> ag = automaticGrading.Where(x => x.Percentage <= percentage).OrderByDescending(x => x.Percentage).ToList();
                    if (ag.Count > 0)
                    {
                        result.Add(item.ID, ag[0].DiscreteGrade.ID);
                    }
                    else
                    {
                        result.Add(item.ID, 0);
                    }
                }
                catch (Exception exc)
                {
                    result.Add(item.ID, 0);
                }
            }

            return result;
        }
    }
}