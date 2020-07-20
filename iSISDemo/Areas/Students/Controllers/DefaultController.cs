using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Models;

namespace iSISDemo.Areas.Students.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Students/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}