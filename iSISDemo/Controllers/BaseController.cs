using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Models;

namespace iSISDemo.Controllers
{
    public class BaseController : Controller
    {
        private WebSessionContext context;
        public virtual WebSessionContext Context
        {
            get
            {
                if (null == context)
                {
                    context = new WebSessionContext(base.Session);   
                }
                return context;
            }
        }
    }
}