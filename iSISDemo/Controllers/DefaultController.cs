using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Filters;
using iSISDemo.Models;
using iSISDemo.Classes;

namespace iSISDemo.Controllers
{
    public class DefaultController : BaseController
    {
        [UserFilterAuthorizeAttribute]
        // GET: Default
        public ActionResult Index()
        {
            if (SessionManager.GetSession(this, SessionManager.SessionName.CurrentModule) == null)
            {
                IList<iSISModel.AuthorizeModule> authorizeModule = (IList<iSISModel.AuthorizeModule>)SessionManager.GetSession(this, SessionManager.SessionName.CurrentAuthorizeModule);
                if (authorizeModule.Count > 0)
                {
                    SessionManager.SetSession(this, SessionManager.SessionName.CurrentModule, ((iSISModel.AuthorizeModule)authorizeModule.Where(x => x.Module.Parent == null).OrderBy(x => x.Module.SeqNo).FirstOrDefault()).Module.ID);
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult ChangeTheme(string CurrentArea, string CurrentController, string CurrentAction, string CurrentURL, string themeSelector_VI)
        {
            CookieManager.SetCookie(this, CookieManager.CookieName.CurrentTheme, themeSelector_VI);
            //return RedirectToAction(CurrentAction, CurrentController, new { area = CurrentArea });
            return Redirect(CurrentURL);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(string CurrentArea, string CurrentController, string CurrentAction, string CurrentURL, string languageSelector_VI)
        {
            CookieManager.SetCookie(this, CookieManager.CookieName.CurrentLanguage, languageSelector_VI);
            //return RedirectToAction(CurrentAction, CurrentController, new { area = CurrentArea });
            return Redirect(CurrentURL);
        }

        [HttpPost]
        public ActionResult ChangeModule(long moduleID)
        {
            SessionManager.SetSession(this, SessionManager.SessionName.CurrentModule, moduleID);
            string navigateUrl = ModelsRepository.GetModulesByID(moduleID).NavigateUrl;
            //return Redirect(ModelsRepository.GetModulesByID(moduleID)[0].NavigateUrl);
            if (navigateUrl.Equals(""))
            {
                return Redirect("~/Default");
            }
            else
            {
                return Redirect(navigateUrl);
            }
        }

        public ActionResult ProvincePartial(string addressCategory)
        {
            ViewData["AddressCategory"] = addressCategory;
            string country = (!string.IsNullOrEmpty(Request.Params["Country"])) ? Request.Params["Country"] : "";
            IList<iSISModel.GeographicRegion> province = ModelsRepository.GetRootGeographicRegion(country);
            return PartialView("~/Views/Shared/_ComboBoxProvince.cshtml", province);
        }

        public ActionResult DistrictPartial(string addressCategory)
        {
            ViewData["AddressCategory"] = addressCategory;
            int provinceID = (!string.IsNullOrEmpty(Request.Params["Province"])) ? int.Parse(Request.Params["Province"]) : 0;
            IList<iSISModel.GeographicRegion> district = ModelsRepository.GetGeographicRegion(provinceID);
            return PartialView("~/Views/Shared/_ComboBoxDistrict.cshtml", district);
        }

        public ActionResult SubdistrictPartial(string addressCategory)
        {
            ViewData["AddressCategory"] = addressCategory;
            int districtID = (!string.IsNullOrEmpty(Request.Params["District"])) ? int.Parse(Request.Params["District"]) : 0;
            IList<iSISModel.GeographicRegion> subdistrict = ModelsRepository.GetGeographicRegion(districtID);
            return PartialView("~/Views/Shared/_ComboBoxSubdistrict.cshtml", subdistrict);
        }

        public ActionResult SemesterPartial(int defaultYear, int defaultSemester, bool isRequired, string validationGroup)
        {
            if (defaultSemester != 0)
            {
                ViewData["SelectedValue"] = defaultSemester;
            }
            ViewData["IsRequired"] = isRequired;
            ViewData["ValidationGroup"] = validationGroup;
            int academicYear = (!string.IsNullOrEmpty(Request.Params["AcademicYear"])) ? int.Parse(Request.Params["AcademicYear"]) : defaultYear;
            IList<iSISModel.Semester> semester = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Semester>()
                                          .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                          .And(x => x.AcademicYear == academicYear)
                                          //.OrderBy(x => x.SemesterNo).Asc
                                          .List();
            List<int> semesterNo = semester.Select(x => x.SemesterNo).ToList();
            semesterNo.Sort();
            return PartialView("~/Views/Shared/_ComboBoxSemester.cshtml", semesterNo);
        }

        public ActionResult CoursePartial(Int64 defaultClassLevel, Int64 defaultCourse, bool isRequired, string validationGroup)
        {
            if (defaultCourse != 0)
            {
                ViewData["SelectedValue"] = defaultCourse;
            }
            ViewData["IsRequired"] = isRequired;
            ViewData["ValidationGroup"] = validationGroup;
            Int64 classLevel = (!string.IsNullOrEmpty(Request.Params["ClassLevel"])) ? Int64.Parse(Request.Params["ClassLevel"]) : defaultClassLevel;
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Course> course = (from n in (IList<iSISModel.Course>)CacheManager.GetCache(CacheManager.CacheName.Course)
                                              where n.School.ID == school.ID && n.Level.ID == classLevel 
                                              select n).ToList();
            return PartialView("~/Views/Shared/_ComboBoxCourse.cshtml", course);
        }

        public ActionResult RoomPartial(Int64 defaultClassLevel, Int64 defaultRoom, bool isRequired, string validationGroup)
        {
            if (defaultRoom != 0)
            {
                ViewData["SelectedValue"] = defaultRoom;
            }
            ViewData["IsRequired"] = isRequired;
            ViewData["ValidationGroup"] = validationGroup;
            Int64 classLevel = (!string.IsNullOrEmpty(Request.Params["ClassLevel"])) ? Int64.Parse(Request.Params["ClassLevel"]) : defaultClassLevel;
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.PhysicalRoom> room = (from n in (IList<iSISModel.PhysicalRoom>)CacheManager.GetCache(CacheManager.CacheName.Room)
                                                  where n.School.ID == school.ID && n.ClassLevel.ID == classLevel
                                                  select n).ToList();
            return PartialView("~/Views/Shared/_ComboBoxRoom.cshtml", room);
        }
    }
}