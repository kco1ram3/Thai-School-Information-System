using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using NHibernate;
using iSISModel;
using TSIS.Controllers;
using System.Globalization;
using TSIS.Models;
using TSIS.Filters;

namespace TSIS.Areas.Announcement.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class AdmissionController : BaseController
    {
        // GET: Announcement/Admission
        public ActionResult Index()
        {
            IList<iSISModel.Admission> admissions = Context.CurrentSchool.Admissions;
            ViewData["Curriculum"] = admissions;
            return View(admissions);
        }
        public ActionResult Admissions()
        {
            IList<iSISModel.Admission> admissions = Context.CurrentSchool.Admissions;
            ViewData["Curriculum"] = admissions;
            return PartialView("~/Areas/Announcement/Views/Admission/_Admissions.cshtml", admissions);
        }
        public ActionResult AdmissionHtmlEditor(iSISModel.Admission admission)
        {
            return PartialView("~/Areas/Announcement/Views/Admission/_AdmissionHtmlEditor.cshtml", admission);
        }
        public ActionResult AdmissionHtmlEditorImageSelectorUpload()
        {
            HtmlEditorExtension.SaveUploadedImage("AdmissionHtmlEditor", AdmissionControllerAdmissionHtmlEditorSettings.ImageSelectorSettings);
            return null;
        }
        public ActionResult AdmissionHtmlEditorImageUpload()
        {
            HtmlEditorExtension.SaveUploadedFile("AdmissionHtmlEditor", AdmissionControllerAdmissionHtmlEditorSettings.ImageUploadValidationSettings, AdmissionControllerAdmissionHtmlEditorSettings.ImageUploadDirectory);
            return null;
        }
        public ActionResult Create()
        {
            ViewData["Semester"] = Context.CurrentSchool.Semesters.Where(s => s.SemesterNo == 1).ToList();
            ViewData["Curriculum"] = Context.CurrentSchool.Curriculums;
            return View("AdmissionUpdate", getAdmission());
        }
        public ActionResult Update(int id)
        {
            ViewData["Semester"] = Context.CurrentSchool.Semesters.Where(s => s.SemesterNo == 1).ToList();
            ViewData["Curriculum"] = Context.CurrentSchool.Curriculums;
            return View("AdmissionUpdate", getAdmission(id));
        }
        [HttpPost]
        public ActionResult Update(int? id, iSISModel.Admission admission, FormCollection collection)
        {
            iSISModel.School school = Context.CurrentSchool;

            Int64 semesterID = (!string.IsNullOrEmpty(collection["ComboBoxAcademicYear_VI"])) ? Int64.Parse(collection["ComboBoxAcademicYear_VI"]) : 0;
            iSISModel.Semester semester = Context.CurrentSchool.Semesters.Where(s => s.ID == semesterID).SingleOrDefault();

            string application_form_url = (!string.IsNullOrEmpty(collection["TextBoxApplicationFormURL"])) ? Request.Form["TextBoxApplicationFormURL"] : string.Empty;
            iSISModel.MultilingualString description = new MultilingualString(Context.CurrentLanguageCode, HtmlEditorExtension.GetHtml("AdmissionHtmlEditor"));

            DateTime apply_from = (!string.IsNullOrEmpty(collection["DateEditStartDate"])) ? DateTime.ParseExact(collection["DateEditStartDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            DateTime apply_to = (!string.IsNullOrEmpty(collection["DateEditEndDate"])) ? DateTime.ParseExact(collection["DateEditEndDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTimeRange.MaxDate;
            DateTimeRange apply_period = new DateTimeRange { From = apply_from, To = apply_to };

            iSISModel.Admission update = null;
            if ((id == null) || (id == 0))
            {
                update = new iSISModel.Admission();
            }
            else
            {
                update = Context.PersistenceSession
                            .QueryOver<iSISModel.Admission>()
                            .Where(a => a.ID == id)
                            .SingleOrDefault();

                update.StudentApplications = admission.StudentApplications;
            }
            update.School = school;
            update.StartSemester = semester;
            update.ApplicationFormURL = application_form_url;
            update.Description = description;
            update.ApplyPeriod = apply_period;

            IList<iSISModel.AdmitCurriculum> tempAdmitCurriculums = ((iSISModel.Admission)TempData["Admission"]).AdmitCurriculums;
            foreach (iSISModel.AdmitCurriculum item in update.AdmitCurriculums)
            {
                iSISModel.AdmitCurriculum tempAdmitCurriculum = tempAdmitCurriculums.Where(ac => ac.ID == item.ID).SingleOrDefault();

                if (tempAdmitCurriculum != null)
                {
                    item.Curriculum = tempAdmitCurriculum.Curriculum;
                    item.Title.AddOrReplace(tempAdmitCurriculum.Title);
                    item.Capacity = tempAdmitCurriculum.Capacity;
                    item.AdmittedClassLevel = tempAdmitCurriculum.AdmittedClassLevel;
                    item.ForLocalPeopleOnly = tempAdmitCurriculum.ForLocalPeopleOnly;
                    item.DrawingPeriod = tempAdmitCurriculum.DrawingPeriod;
                    item.RegistrationPeriod = tempAdmitCurriculum.RegistrationPeriod;
                    item.TestPeriod = tempAdmitCurriculum.TestPeriod;
                    item.TestResultPublishedDate = tempAdmitCurriculum.TestResultPublishedDate;
                    item.ApplicationFormURL = tempAdmitCurriculum.ApplicationFormURL;
                    item.EffectivePeriod = tempAdmitCurriculum.EffectivePeriod;
                }
                else
                {
                    item.EffectivePeriod.ExpiryDate = DateTime.Today;
                }
            }
            foreach (iSISModel.AdmitCurriculum item in tempAdmitCurriculums.Where(x => x.ID <= 0).ToList())
            {
                update.AdmitCurriculums.Add(new iSISModel.AdmitCurriculum
                {
                    Curriculum = item.Curriculum,
                    Title = item.Title,
                    Capacity = item.Capacity,
                    AdmittedClassLevel = item.AdmittedClassLevel,
                    ForLocalPeopleOnly = item.ForLocalPeopleOnly,
                    DrawingPeriod = item.DrawingPeriod,
                    RegistrationPeriod = item.RegistrationPeriod,
                    TestPeriod = item.TestPeriod,
                    TestResultPublishedDate = item.TestResultPublishedDate,
                    ApplicationFormURL = item.ApplicationFormURL,
                    EffectivePeriod = item.EffectivePeriod,
                });
            }

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    update.Persist(base.Context);
                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            iSISModel.Admission admission = Context.CurrentSchool.Admissions.Where(a => a.ID == id).SingleOrDefault();
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    admission.ApplyPeriod.To = DateTime.Today;
                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }

            return RedirectToAction("Index");
        }
        public string getDescription(int id)
        {
            return getAdmission(id).Description.GetValue(Context.CurrentLanguageCode);
        }
        private Admission getAdmission(int id = 0)
        {
            Admission admission = null;

            if (id == 0)
            {
                admission = new Admission();
            }
            else
            {
                admission = Context.CurrentSchool.Admissions.Where(a => a.ID == id).SingleOrDefault();
            }
            TempData["Admission"] = admission;
            return admission;
        }
    }
    public class AdmissionControllerAdmissionHtmlEditorSettings
    {
        public const string ImageUploadDirectory = "~/Content/UploadImages/";
        public const string ImageSelectorThumbnailDirectory = "~/Content/Thumb/";

        public static DevExpress.Web.UploadControlValidationSettings ImageUploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" },
            MaxFileSize = 4000000
        };

        static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings imageSelectorSettings;
        public static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings ImageSelectorSettings
        {
            get
            {
                if (imageSelectorSettings == null)
                {
                    imageSelectorSettings = new DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings(null);
                    imageSelectorSettings.Enabled = true;
                    imageSelectorSettings.UploadCallbackRouteValues = new { Controller = "Default", Action = "AdmissionHtmlEditorImageSelectorUpload" };
                    imageSelectorSettings.CommonSettings.RootFolder = ImageUploadDirectory;
                    imageSelectorSettings.CommonSettings.ThumbnailFolder = ImageSelectorThumbnailDirectory;
                    imageSelectorSettings.CommonSettings.AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif" };
                    imageSelectorSettings.UploadSettings.Enabled = true;
                }
                return imageSelectorSettings;
            }
        }
    }
}