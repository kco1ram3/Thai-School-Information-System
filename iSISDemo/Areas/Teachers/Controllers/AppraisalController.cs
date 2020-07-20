using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Controllers;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Areas.Teachers.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class AppraisalController : BaseController
    {
        // GET: Teachers/Appraisal
        public ActionResult Index()
        {
            return View(getTeacherList());
        }

        public ActionResult GridViewTeacherAppraisalList()
        {
            return PartialView("_GridViewTeacherAppraisalList", getTeacherList());
        }

        public ActionResult CourseSection(int id = 0)
        {
            if (id == 0)
            {
                iSISModel.User user = (iSISModel.User)SessionManager.GetSession(this, SessionManager.SessionName.CurrentUser);
                id = user.Person.ID;
            }
            ViewData["id"] = id;
            return View(getCourseSectionTeacherList(id));
        }

        public ActionResult GridViewCourseSectionTeacherList(int id)
        {
            ViewData["id"] = id;
            return PartialView("_GridViewCourseSectionTeacherList", getCourseSectionTeacherList(id));
        }

        private IList<iSISModel.Teacher> getTeacherList()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Teacher> teacher = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.Teacher>()
                                               .Where(t => t.EffectivePeriod.To > DateTime.Today)
                                               .And(t => t.School == school)
                                               .List();
            return teacher;
        }

        private IList<iSISModel.CourseSectionTeacher> getCourseSectionTeacherList(int id)
        {
            iSISModel.Person person = base.Context.PersistenceSession
                                 .QueryOver<iSISModel.Person>()
                                 .Where(x => x.ID == id)
                                 .SingleOrDefault();

            if (person != null)
            {
                ViewData["PersonName"] = person.CurrentName.ToString(CookieManager.GetCookie(this, CookieManager.CookieName.CurrentLanguage));
            }

            iSISModel.Teacher teacher = base.Context.PersistenceSession
                                 .QueryOver<iSISModel.Teacher>()
                                 .Where(x => x.Person.ID == id)
                                 .SingleOrDefault();

            IList<iSISModel.CourseSectionTeacher> courseSectionTeacher = base.Context.PersistenceSession
                .QueryOver<iSISModel.CourseSectionTeacher>()
                .Where(x => x.Teacher.ID == teacher.ID)
                .And(x => x.EffectivePeriod.To > DateTime.Today)
                //.OrderBy(x => x.SeqNo).Asc
                .List();

            return courseSectionTeacher;
        }
    }
}