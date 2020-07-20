using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSIS.Filters;
using TSIS.Controllers;

namespace TSIS.Areas.Teacher.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class EducationsController : BaseController
    {
        // GET: Teacher/Educations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridViewEducations()
        {
            iSISModel.HierarchicalCategory educationLevel = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "EducationLevel").And(l => l.Parent == null)
                                               .SingleOrDefault();
            ViewData["EducationLevel"] = educationLevel.Children;

            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewEducations", teacher);
        }

        [HttpPost]
        public ActionResult GridViewEducationsAddNew(iSISModel.Education education, FormCollection collection)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int? id = teacher.Person.Educations.Min(x => (int?)x.ID);
            if (id >= 0 || id == null)
            {
                id = -1;
            }
            else
            {
                id -= 1;
            }
            education.ID = (long)id;
            teacher.Person.Educations.Add(education);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewEducations", teacher);
        }

        [HttpPost]
        public ActionResult GridViewEducationsUpdate(iSISModel.Education education, FormCollection collection)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int index = teacher.Person.Educations.IndexOf(teacher.Person.Educations.Where(x => x.ID == education.ID).SingleOrDefault());
            teacher.Person.Educations.RemoveAt(index);
            teacher.Person.Educations.Insert(index, education);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewEducations", teacher);
        }

        [HttpPost]
        public ActionResult GridViewEducationsDelete(int ID)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int index = teacher.Person.Educations.IndexOf(teacher.Person.Educations.Where(x => x.ID == ID).SingleOrDefault());
            teacher.Person.Educations.RemoveAt(index);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewEducations", teacher);
        }
    }
}