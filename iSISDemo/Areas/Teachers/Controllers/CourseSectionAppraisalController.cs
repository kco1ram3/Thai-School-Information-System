using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Controllers;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;

namespace iSISDemo.Areas.Teachers.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class CourseSectionAppraisalController : BaseController
    {
        // GET: Teachers/CourseSectionAppraisal
        public ActionResult Index(int id)
        {
            ViewData["courseSectionID"] = id;
            ViewData["CourseSection"] = getCourseSection(id);

            return View(getCourseSectionAppraisalList(id));
        }

        public ActionResult GridViewCourseSectionAppraisal(int courseSectionID)
        {
            ViewData["courseSectionID"] = courseSectionID;
            return PartialView("_GridViewCourseSectionAppraisal", getCourseSectionAppraisalList(courseSectionID));
        }

        [HttpPost]
        public ActionResult GridViewCourseSectionAppraisalAddNewOrUpdate(iSISModel.CourseSectionAppraisal courseSectionAppraisal, FormCollection collection, int courseSectionID)
        {
            ViewData["courseSectionID"] = courseSectionID;
            iSISModel.CourseSectionAppraisal update = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.CourseSectionAppraisal>()
                                           .Where(x => x.ID == courseSectionAppraisal.ID)
                                           .SingleOrDefault();
            if (update == null)
            {
                update = new iSISModel.CourseSectionAppraisal();
                update.CourseSection = getCourseSection(courseSectionID);
                update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
            }

            update.SeqNo = courseSectionAppraisal.SeqNo;
            update.AppraisalDate = courseSectionAppraisal.AppraisalDate;
            if (update.Title == null)
            {
                update.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            }
            else
            {
                update.Title.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "Title"));
            }
            if (update.Description == null)
            {
                update.Description = ModelsRepository.GetTextBoxMultiLanguages(collection, "Description");
            }
            else
            {
                update.Description.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "Description"));
            }
            update.PerfectScore = courseSectionAppraisal.PerfectScore;
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
            return PartialView("_GridViewCourseSectionAppraisal", getCourseSectionAppraisalList(courseSectionID));
        }

        [HttpPost]
        public ActionResult GridViewCourseSectionAppraisalDelete(int ID, int courseSectionID)
        {
            ViewData["courseSectionID"] = courseSectionID;
            iSISModel.CourseSectionAppraisal courseSectionAppraisal = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.CourseSectionAppraisal>()
                                           .Where(x => x.ID == ID)
                                           .SingleOrDefault();
            courseSectionAppraisal.EffectivePeriod.To = DateTime.Today;
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    courseSectionAppraisal.Persist(base.Context);
                    //base.Context.PersistenceSession.Delete(courseSectionAppraisal);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewCourseSectionAppraisal", getCourseSectionAppraisalList(courseSectionID));
        }

        private iSISModel.CourseSection getCourseSection(int courseSectionID)
        {
            iSISModel.CourseSection courseSection = base.Context.PersistenceSession
                .QueryOver<iSISModel.CourseSection>()
                .Where(x => x.ID == courseSectionID)
                .SingleOrDefault();

            return courseSection;
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
    }
}