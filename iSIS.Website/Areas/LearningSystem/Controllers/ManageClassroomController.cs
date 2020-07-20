using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web;
using System.Web.SessionState;
using DevExpress.Web.Mvc;
using iSISModel;
using iSIS.Website.Models;
using System.Collections.Generic;

namespace iSIS.Website.Areas.LearningSystem.Controllers
{
    public class ManageClassroomController : Controller
    {
        #region --- Editing Classroom ---
        private ClassLevelSection classLevelSection = InitializeData.GetClassLevelSection(1, 1);
        public ActionResult EditFormClassroom()
        {
            return View("EditFormClassroom", classLevelSection);
        }

        [ValidateInput(false)]
        public ActionResult EditFormClassroomPartial()
        {
            return PartialView("EditFormClassroomPartial", classLevelSection);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditFormClassroomAddNewPartial(Classroom item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //NorthwindDataProvider.InsertProduct(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["EditableClassroom"] = item;
            }
            return PartialView("EditFormClassroomPartial", classLevelSection);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditFormClassroomUpdatePartial(Classroom item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //NorthwindDataProvider.UpdateProduct(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["EditableClassroom"] = item;
            }

            return PartialView("EditFormClassroomPartial", classLevelSection);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditFormClassroomDeletePartial(int itemId)
        {
            if (itemId > 0)
            {
                try
                {
                    //NorthwindDataProvider.DeleteProduct(itemId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("EditFormClassroomPartial", classLevelSection);
        }
        #endregion
    }
}