using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Filters;

namespace iSISDemo.Areas.Teachers.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class ExperiencesController : Controller
    {
        // GET: Teachers/Experiences
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridViewExperiences()
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewExperiences", teacher);
        }

        [HttpPost]
        public ActionResult GridViewExperiencesAddNew(iSISModel.Experience experience, FormCollection collection)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int? id = teacher.Person.Experiences.Min(x => (int?)x.ID);
            if (id >= 0 || id == null)
            {
                id = -1;
            }
            else
            {
                id -= 1;
            }
            experience.ID = (long)id;
            teacher.Person.Experiences.Add(experience);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewExperiences", teacher);
        }

        [HttpPost]
        public ActionResult GridViewExperiencesUpdate(iSISModel.Experience experience, FormCollection collection)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int index = teacher.Person.Experiences.IndexOf(teacher.Person.Experiences.Where(x => x.ID == experience.ID).SingleOrDefault());
            teacher.Person.Experiences.RemoveAt(index);
            teacher.Person.Experiences.Insert(index, experience);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewExperiences", teacher);
        }

        [HttpPost]
        public ActionResult GridViewExperiencesDelete(int ID)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int index = teacher.Person.Experiences.IndexOf(teacher.Person.Experiences.Where(x => x.ID == ID).SingleOrDefault());
            teacher.Person.Experiences.RemoveAt(index);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewExperiences", teacher);
        }
    }
}