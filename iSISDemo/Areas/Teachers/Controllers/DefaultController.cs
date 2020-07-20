using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Controllers;
using iSISDemo.Filters;

namespace iSISDemo.Areas.Teachers.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class DefaultController : BaseController
    {

        // GET: Teachers/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}