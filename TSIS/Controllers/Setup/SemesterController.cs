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
    public class SemesterController : BaseController
    {
        // GET: Semester
        public ActionResult Index()
        {
            return View(SemesterData());
        }

        public ActionResult GridViewSemesterData()
        {
            return PartialView("_GridViewSemesterData", SemesterData());
        }

        [HttpPost]
        public ActionResult GridViewSemesterDataAddNewOrUpdate(iSISModel.Semester semester, FormCollection collection)
        {
            iSISModel.Semester update = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Semester>()
                                          .Where(x => x.ID == semester.ID)
                                          .SingleOrDefault();

            DateTime applicationPeriodFrom = (!string.IsNullOrEmpty(collection["ApplicationPeriodFrom"])) ? DateTime.Parse(collection["ApplicationPeriodFrom"]) : DateTime.Today;
            DateTime applicationPeriodTo = (!string.IsNullOrEmpty(collection["ApplicationPeriodTo"])) ? DateTime.Parse(collection["ApplicationPeriodTo"]) : DateTime.Today;
            DateTime teachingPeriodFrom = (!string.IsNullOrEmpty(collection["TeachingPeriodFrom"])) ? DateTime.Parse(collection["TeachingPeriodFrom"]) : DateTime.Today;
            DateTime teachingPeriodTo = (!string.IsNullOrEmpty(collection["TeachingPeriodTo"])) ? DateTime.Parse(collection["TeachingPeriodTo"]) : DateTime.Today;
            DateTime finalExamPeriodFrom = (!string.IsNullOrEmpty(collection["FinalExamPeriodFrom"])) ? DateTime.Parse(collection["FinalExamPeriodFrom"]) : DateTime.Today;
            DateTime finalExamPeriodTo = (!string.IsNullOrEmpty(collection["FinalExamPeriodTo"])) ? DateTime.Parse(collection["FinalExamPeriodTo"]) : DateTime.Today;

            if (update == null)
            {
                update = new iSISModel.Semester();
                update.School = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
                update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
            }
            update.AcademicYear = semester.AcademicYear;
            update.SemesterNo = semester.SemesterNo;
            update.ApplicationPeriod = new iSISModel.DateTimeRange(applicationPeriodFrom, applicationPeriodTo);
            update.TeachingPeriod = new iSISModel.DateTimeRange(teachingPeriodFrom, teachingPeriodTo);
            update.FinalExamPeriod = new iSISModel.DateTimeRange(finalExamPeriodFrom, finalExamPeriodTo);

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
            SetupClassLevelSection(update);
            return PartialView("_GridViewSemesterData", SemesterData());
        }

        [HttpPost]
        public ActionResult GridViewSemesterDataDelete(long ID)
        {
            iSISModel.Semester semester = base.Context.PersistenceSession
                                            .QueryOver<iSISModel.Semester>()
                                            .Where(x => x.ID == ID)
                                            .SingleOrDefault();

            semester.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    semester.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            SetupClassLevelSection(semester, true);
            return PartialView("_GridViewSemesterData", SemesterData());
        }

        private IList<iSISModel.Semester> SemesterData()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Semester> semester = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.Semester>()
                                                .Where(x => x.School == school).And(x => x.EffectivePeriod.To > DateTime.Today)
                                                .OrderBy(x => x.AcademicYear).Asc
                                                .OrderBy(x => x.SemesterNo).Asc
                                                .List();
            return semester;
        }

        private void SetupClassLevelSection(iSISModel.Semester semester, bool isDelete = false)
        {
            if (isDelete)
            {
                IList<iSISModel.ClassLevelSection> classLevelSection = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevelSection>()
                                                .Where(x => x.Semester == semester)
                                                .List();

                using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        foreach (iSISModel.ClassLevelSection i in classLevelSection)
                        {
                            i.EffectivePeriod.To = DateTime.Today;
                            i.Persist(Context);
                        }

                        tran.Commit();
                    }
                    catch (Exception exc)
                    {
                        tran.Rollback();
                        throw exc;
                    }
                }
            }
            else
            {
                IList<iSISModel.ClassLevel> classLevel = (IList<iSISModel.ClassLevel>)CacheManager.GetCache(CacheManager.CacheName.ClassLevel);
                iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);

                foreach (iSISModel.ClassLevel i in classLevel)
                {
                    iSISModel.ClassLevelSection classLevelSection = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevelSection>()
                                                .Where(x => x.ClassLevel == i)
                                                .And(x => x.School == school)
                                                .And(x => x.Semester == semester)
                                                .SingleOrDefault();

                    if (classLevelSection == null)
                    {
                        classLevelSection = new iSISModel.ClassLevelSection();
                        classLevelSection.School = school;
                        classLevelSection.ClassLevel = i;
                        classLevelSection.Semester = semester;
                        classLevelSection.EffectivePeriod = semester.EffectivePeriod;
                        classLevelSection.Persist(base.Context);
                    }
                }
            }
        }
    }
}