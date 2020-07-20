﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSIS.Controllers;
using TSIS.Filters;

namespace TSIS.Areas.Student.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class DefaultController : BaseController
    {
        // GET: Student/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}