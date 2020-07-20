using iSISModel;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSIS.Controllers;
using TSIS.Models;
using TSIS.Filters;
using TSIS.Classes;

namespace TSIS.Areas.Announcement.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class AdmitCurriculumsController : BaseController
    {
        // GET: Announcement/AdmitCurriculums
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdmitCurriculumsDetail(int AdmissionID, bool EditMode)
        {
            ViewData["EditMode"] = EditMode;
            ViewData["AdmissionID"] = AdmissionID;
            ViewData["Curriculum"] = Context.CurrentSchool.Curriculums;
            ViewData["ClassLevel"] = CacheManager.GetCache(CacheManager.CacheName.ClassLevel);
            iSISModel.Admission admission = (iSISModel.Admission)TempData["Admission"];
            TempData["Admission"] = admission;
            return PartialView("_AdmitCurriculums", admission.AdmitCurriculums);
        }
        [HttpPost]
        public ActionResult AdmitCurriculumPartialAddNew(iSISModel.AdmitCurriculum AdmitCurriculum, FormCollection collection,
            int AdmissionID, bool EditMode)
        {
            ViewData["EditMode"] = EditMode;
            ViewData["AdmissionID"] = AdmissionID;
            ViewData["Curriculum"] = Context.CurrentSchool.Curriculums;
            ViewData["ClassLevel"] = CacheManager.GetCache(CacheManager.CacheName.ClassLevel);
            iSISModel.Admission admission = (iSISModel.Admission)TempData["Admission"];

            DateTime DrawingPeriodFrom = (!string.IsNullOrEmpty(collection["DrawingPeriodFrom"])) ? DateTime.ParseExact(collection["DrawingPeriodFrom"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            DateTime DrawingPeriodTo = (!string.IsNullOrEmpty(collection["DrawingPeriodTo"])) ? DateTime.ParseExact(collection["DrawingPeriodTo"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;
            DateTime RegistrationPeriodFrom = (!string.IsNullOrEmpty(collection["RegistrationPeriodFrom"])) ? DateTime.ParseExact(collection["RegistrationPeriodFrom"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            DateTime RegistrationPeriodTo = (!string.IsNullOrEmpty(collection["RegistrationPeriodTo"])) ? DateTime.ParseExact(collection["RegistrationPeriodTo"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;
            DateTime TestPeriodFrom = (!string.IsNullOrEmpty(collection["TestPeriodFrom"])) ? DateTime.ParseExact(collection["TestPeriodFrom"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            DateTime TestPeriodTo = (!string.IsNullOrEmpty(collection["TestPeriodTo"])) ? DateTime.ParseExact(collection["TestPeriodTo"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;
            DateTime TestResultPublishedDate = (!string.IsNullOrEmpty(collection["TestResultPublishedDate"])) ? DateTime.ParseExact(collection["TestResultPublishedDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;

            bool ForLocalPeopleOnly = false;
            if (collection["ForLocalPeopleOnly"].ToString() == "C")
                ForLocalPeopleOnly = true;

            int capacity = (!string.IsNullOrEmpty(collection["SpinEditCapacity"])) ? int.Parse(collection["SpinEditCapacity"]) : 0;

            Int64 AdmittedClassLevelNo = (!string.IsNullOrEmpty(collection["ComboBoxAdmittedClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxAdmittedClassLevel_VI"]) : 0;
            iSISModel.ClassLevel AdmittedClassLevel = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevel>()
                                                .Where(c => c.LevelNo == AdmittedClassLevelNo)
                                                .SingleOrDefault();
            iSISModel.MultilingualString Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "TextBoxTitle");

            string ApplicationFormURL = collection["TextBoxApplicationFormURL"].ToString();
            Int64 CurriculumID = (!string.IsNullOrEmpty(collection["ComboBoxCurriculum_VI"])) ? Int64.Parse(collection["ComboBoxCurriculum_VI"]) : 0;
            iSISModel.Curriculum curriculum = Context.CurrentSchool.Curriculums.Where(c => c.ID == CurriculumID).SingleOrDefault();

            int? id = admission.AdmitCurriculums.Min(a => (int?)a.ID);
            if ((id >= 0) || (id == null))
            {
                id = -1;
            }
            else
            {
                id -= 1;
            }
            AdmitCurriculum.ID = (long)id;
            AdmitCurriculum.Capacity = capacity;
            AdmitCurriculum.Curriculum = curriculum;
            AdmitCurriculum.Admission = admission;
            AdmitCurriculum.Title = Title;
            AdmitCurriculum.AdmittedClassLevel = AdmittedClassLevel;
            AdmitCurriculum.ForLocalPeopleOnly = ForLocalPeopleOnly;
            AdmitCurriculum.DrawingPeriod = new DateTimeRange { From = DrawingPeriodFrom, To = DrawingPeriodTo };
            AdmitCurriculum.RegistrationPeriod = new DateTimeRange { From = RegistrationPeriodFrom, To = RegistrationPeriodTo };
            AdmitCurriculum.TestPeriod = new DateTimeRange { From = TestPeriodFrom, To = TestPeriodTo };
            AdmitCurriculum.TestResultPublishedDate = TestResultPublishedDate;
            AdmitCurriculum.ApplicationFormURL = ApplicationFormURL;
            AdmitCurriculum.EffectivePeriod = new DateTimeRange(DateTime.Today);

            admission.AdmitCurriculums.Add(AdmitCurriculum);
            TempData["Admission"] = admission;
            return PartialView("_AdmitCurriculums", admission.AdmitCurriculums);
        }
        [HttpPost]
        public ActionResult AdmitCurriculumPartialUpdate(iSISModel.AdmitCurriculum AdmitCurriculum, FormCollection collection,
            int AdmissionID, bool EditMode)
        {
            ViewData["EditMode"] = EditMode;
            ViewData["AdmissionID"] = AdmissionID;
            ViewData["Curriculum"] = Context.CurrentSchool.Curriculums;
            ViewData["ClassLevel"] = CacheManager.GetCache(CacheManager.CacheName.ClassLevel);
            iSISModel.Admission admission = (iSISModel.Admission)TempData["Admission"];

            iSISModel.AdmitCurriculum update = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.AdmitCurriculum>()
                                                .Where(x => x.ID == AdmitCurriculum.ID)
                                                .SingleOrDefault();

            DateTime DrawingPeriodFrom = (!string.IsNullOrEmpty(collection["DrawingPeriodFrom"])) ? DateTime.ParseExact(collection["DrawingPeriodFrom"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            DateTime DrawingPeriodTo = (!string.IsNullOrEmpty(collection["DrawingPeriodTo"])) ? DateTime.ParseExact(collection["DrawingPeriodTo"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;
            DateTime RegistrationPeriodFrom = (!string.IsNullOrEmpty(collection["RegistrationPeriodFrom"])) ? DateTime.ParseExact(collection["RegistrationPeriodFrom"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            DateTime RegistrationPeriodTo = (!string.IsNullOrEmpty(collection["RegistrationPeriodTo"])) ? DateTime.ParseExact(collection["RegistrationPeriodTo"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;
            DateTime TestPeriodFrom = (!string.IsNullOrEmpty(collection["TestPeriodFrom"])) ? DateTime.ParseExact(collection["TestPeriodFrom"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            DateTime TestPeriodTo = (!string.IsNullOrEmpty(collection["TestPeriodTo"])) ? DateTime.ParseExact(collection["TestPeriodTo"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;
            DateTime TestResultPublishedDate = (!string.IsNullOrEmpty(collection["TestResultPublishedDate"])) ? DateTime.ParseExact(collection["TestResultPublishedDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;

            bool ForLocalPeopleOnly = false;
            if (collection["ForLocalPeopleOnly"].ToString() == "C")
                ForLocalPeopleOnly = true;

            int capacity = (!string.IsNullOrEmpty(collection["SpinEditCapacity"])) ? int.Parse(collection["SpinEditCapacity"]) : 0;

            Int64 AdmittedClassLevelNo = (!string.IsNullOrEmpty(collection["ComboBoxAdmittedClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxAdmittedClassLevel_VI"]) : 0;
            iSISModel.ClassLevel AdmittedClassLevel = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevel>()
                                                .Where(c => c.LevelNo == AdmittedClassLevelNo)
                                                .SingleOrDefault();
            iSISModel.MultilingualString Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "TextBoxTitle");

            string ApplicationFormURL = collection["TextBoxApplicationFormURL"].ToString();
            Int64 CurriculumID = (!string.IsNullOrEmpty(collection["ComboBoxCurriculum"])) ? Int64.Parse(collection["ComboBoxCurriculum_VI"]) : 0;
            iSISModel.Curriculum curriculum = Context.CurrentSchool.Curriculums.Where(c => c.ID == CurriculumID).SingleOrDefault();

            update.Capacity = capacity;
            update.Curriculum = curriculum;
            update.Admission = admission;
            update.Title = Title;
            update.AdmittedClassLevel = AdmittedClassLevel;
            update.ForLocalPeopleOnly = ForLocalPeopleOnly;
            update.DrawingPeriod = new DateTimeRange { From = DrawingPeriodFrom, To = DrawingPeriodTo };
            update.RegistrationPeriod = new DateTimeRange { From = RegistrationPeriodFrom, To = RegistrationPeriodTo };
            update.TestPeriod = new DateTimeRange { From = TestPeriodFrom, To = TestPeriodTo };
            update.TestResultPublishedDate = TestResultPublishedDate;
            update.ApplicationFormURL = ApplicationFormURL;
            update.EffectivePeriod = new DateTimeRange(DateTime.Today);

            int index = admission.AdmitCurriculums.IndexOf(admission.AdmitCurriculums.Where(ac => ac.ID == AdmitCurriculum.ID).SingleOrDefault());
            admission.AdmitCurriculums.RemoveAt(index);
            admission.AdmitCurriculums.Insert(index, update);
            TempData["Admission"] = admission;
            return PartialView("_AdmitCurriculums", admission.AdmitCurriculums);
        }
        [HttpPost]
        public ActionResult AdmitCurriculumPartialDelete(iSISModel.AdmitCurriculum AdmitCurriculum, FormCollection collection,
            int AdmissionID, bool EditMode)
        {
            ViewData["EditMode"] = EditMode;
            ViewData["AdmissionID"] = AdmissionID;
            ViewData["Curriculum"] = Context.CurrentSchool.Curriculums;
            ViewData["ClassLevel"] = CacheManager.GetCache(CacheManager.CacheName.ClassLevel);
            iSISModel.Admission admission = (iSISModel.Admission)TempData["Admission"];
            int index = admission.AdmitCurriculums.IndexOf(admission.AdmitCurriculums.Where(ac => ac.ID == AdmitCurriculum.ID).SingleOrDefault());
            admission.AdmitCurriculums.RemoveAt(index);
            TempData["Admission"] = admission;
            return PartialView("_AdmitCurriculums", admission.AdmitCurriculums);
        }
    }
}