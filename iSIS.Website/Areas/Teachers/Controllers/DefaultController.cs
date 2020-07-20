using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSIS.Website.Areas.Teachers.Models;

namespace iSIS.Website.Areas.Teachers.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Teachers/Default
        public ActionResult Index()
        {
            if (Session["CurrentTheme"] == null)
                Session["CurrentTheme"] = Themes.GetThemes()[0].Value;

            if (Session["CurrentLanguage"] == null)
                Session["CurrentLanguage"] = Languages.GetLanguages()[0].LanguageCode;

            if (Session["CurrentSchool"] == null)
                Session["CurrentSchool"] = new School();

            return View();
        }

        [HttpPost]
        public ActionResult ChangeTheme(string CurrentController, string CurrentAction, string themeSelector_VI)
        {
            Session["CurrentTheme"] = themeSelector_VI;
            return RedirectToAction(CurrentAction, CurrentController);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(string CurrentController, string CurrentAction, string languageSelector_VI)
        {
            Session["CurrentLanguage"] = languageSelector_VI;
            return RedirectToAction(CurrentAction, CurrentController);
        }
    }
}