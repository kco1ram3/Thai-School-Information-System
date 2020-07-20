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
    public class RoyalDecorationsController : BaseController
    {
        // GET: Teacher/RoyalDecorations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridViewRoyalDecorations()
        {
            iSISModel.HierarchicalCategory royalDecoration = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "RoyalDecoration").And(l => l.Parent == null)
                                               .SingleOrDefault();
            ViewData["RoyalDecoration"] = royalDecoration.Children;

            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewRoyalDecorations", teacher);
        }

        [HttpPost]
        public ActionResult GridViewRoyalDecorationsAddNew(iSISModel.RoyalDecoration royalDecoration, FormCollection collection)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int? id = teacher.Person.RoyalDecorations.Min(x => (int?)x.ID);
            if (id >= 0 || id == null)
            {
                id = -1;
            }
            else
            {
                id -= 1;
            }
            royalDecoration.ID = (long)id;
            teacher.Person.RoyalDecorations.Add(royalDecoration);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewRoyalDecorations", teacher);
        }

        [HttpPost]
        public ActionResult GridViewRoyalDecorationsUpdate(iSISModel.RoyalDecoration royalDecoration, FormCollection collection)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int index = teacher.Person.RoyalDecorations.IndexOf(teacher.Person.RoyalDecorations.Where(x => x.ID == royalDecoration.ID).SingleOrDefault());
            teacher.Person.RoyalDecorations.RemoveAt(index);
            teacher.Person.RoyalDecorations.Insert(index, royalDecoration);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewRoyalDecorations", teacher);
        }

        [HttpPost]
        public ActionResult GridViewRoyalDecorationsDelete(int ID)
        {
            iSISModel.Teacher teacher = (iSISModel.Teacher)TempData["Teacher"];
            int index = teacher.Person.RoyalDecorations.IndexOf(teacher.Person.RoyalDecorations.Where(x => x.ID == ID).SingleOrDefault());
            teacher.Person.RoyalDecorations.RemoveAt(index);
            TempData["Teacher"] = teacher;
            return PartialView("_GridViewRoyalDecorations", teacher);
        }
    }
}