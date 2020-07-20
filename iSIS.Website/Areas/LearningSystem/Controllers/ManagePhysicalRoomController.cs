using System;
using System.Collections.Generic;
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
    public class ManagePhysicalRoomController : Controller
    {
        #region --- Editing Physical Room ---
        private List<PhysicalRoom> physicalRoom = InitializeData.GetRooms();

        public ActionResult EditFormPhysicalRoom()
        {
            ViewData["AutocompleteOptions"] = new AutocompleteOption();
            return View("EditFormPhysicalRoom", physicalRoom);
        }

        [ValidateInput(false)]
        public ActionResult EditFormPhysicalRoomPartial()
        {
            return PartialView("EditFormPhysicalRoomPartial", physicalRoom);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditFormPhysicalRoomAddNewPartial(PhysicalRoom item)
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
                ViewData["EditablePhysicalRoom"] = item;
            }
            return PartialView("EditFormPhysicalRoomPartial", physicalRoom);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditFormPhysicalRoomUpdatePartial(PhysicalRoom item)
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
                ViewData["EditablePhysicalRoom"] = item;
            }

            return PartialView("EditFormPhysicalRoomPartial", physicalRoom);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditFormPhysicalRoomDeletePartial(int itemId)
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
            return PartialView("EditFormPhysicalRoomPartial", physicalRoom);
        }
        #endregion
    }
}