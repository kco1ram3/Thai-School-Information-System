using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.Mvc;
using iSISModel;
using iSISDemo.Models;
using iSISDemo.Controllers;
using NHibernate;
using DevExpress.Web;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Areas.Teachers.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class TeachersDetailController : BaseController
    {
        // GET: Teachers/TeachersDetail
        public ActionResult Index()
        {
            return View(getTeacherList());
        }

        public ActionResult GridViewTeacherList()
        {
            return PartialView("_GridViewTeacherList", getTeacherList());
        }

        public ActionResult Create()
        {
            ViewData["FormType"] = "New";
            return View("CreateOrUpdate", getTeacherDetail(0));
        }

        [HttpPost]
        public ActionResult Create(iSISModel.Teacher teacher, FormCollection collection)
        {
            CreateOrUpdateTeacher(0, teacher, collection);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewData["FormType"] = "Edit";
            return View("CreateOrUpdate", getTeacherDetail(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, iSISModel.Teacher teacher, FormCollection collection)
        {
            CreateOrUpdateTeacher(id, teacher, collection);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            iSISModel.Teacher teacher = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.Teacher>()
                                               .Where(t => t.ID == id)
                                               .SingleOrDefault();
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    teacher.EffectivePeriod.To = DateTime.Today;
                    teacher.Persist(base.Context);

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

        public ActionResult Image(int id)
        {
            iSISModel.Teacher teacher = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.Teacher>()
                                               .Where(t => t.ID == id)
                                               .SingleOrDefault();
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Image(int id, UploadedFile[] ucMultiFile)
        {
            if (Request.Params["btnSave"] != null)
            {
                if (ucMultiFile != null)
                {
                    string [] imageContentType  = { "image/gif", "image/jpeg", "image/pjpeg", "image/png" };
                    double maximumFileSize = (2 * 1024f) * 1024f;
                    iSISModel.Teacher teacher = base.Context.PersistenceSession
                                                       .QueryOver<iSISModel.Teacher>()
                                                       .Where(t => t.ID == id)
                                                       .SingleOrDefault();
                    using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                    {
                        try
                        {
                            for (int index = 0; index < ucMultiFile.Length; index++)
                            {
                                if (ucMultiFile[index].FileBytes.Length > 0 && ucMultiFile[index].IsValid && imageContentType.Contains(ucMultiFile[index].ContentType) && ucMultiFile[index].ContentLength <= maximumFileSize)
                                {
                                    Image original = System.Drawing.Image.FromStream(ucMultiFile[index].FileContent);
                                    ImageConverter converter = new ImageConverter();
                                    teacher.Person.Photos.Add(new Photo
                                    {
                                        Image = (byte[])converter.ConvertTo(original, typeof(byte[])),
                                        Date = DateTime.Now
                                    });
                                }
                            }
                            teacher.Persist(base.Context);

                            tran.Commit();

                        }
                        catch (Exception exc)
                        {
                            tran.Rollback();
                            throw exc;
                        }
                    }
                }
            }

            return RedirectToAction("Image");
        }

        public ActionResult DeleteImage(int id, int image_id)
        {
            iSISModel.Photo photo = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.Photo>()
                                           .Where(p => p.ID == image_id)
                                           .SingleOrDefault();
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    base.Context.PersistenceSession.Delete(photo);

                    tran.Commit();

                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }

            return RedirectToAction("Image", new { id = id });
        }

        private IList<iSISModel.Teacher> getTeacherList()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Teacher> teacher = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.Teacher>()
                                               .Where(t => t.EffectivePeriod.To > DateTime.Today)
                                               .And(t => t.School == school)
                                               .List();
            return teacher;
        }

        private iSISModel.Teacher getTeacherDetail(int id)
        {
            iSISModel.HierarchicalCategory bloodGroup = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "BloodGroup").And(l => l.Parent == null)
                                               .SingleOrDefault();

            iSISModel.HierarchicalCategory genderCategory = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "GenderCategory").And(l => l.Parent == null)
                                               .SingleOrDefault();

            iSISModel.HierarchicalCategory raceCategory = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "RaceCategory").And(l => l.Parent == null)
                                               .SingleOrDefault();

            iSISModel.HierarchicalCategory religionCategory = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "ReligionCategory").And(l => l.Parent == null)
                                               .SingleOrDefault();

            IList<iSISModel.Country> country = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.Country>()
                                               .List();

            ViewData["BloodGroup"] = bloodGroup.Children;
            ViewData["GenderCategory"] = genderCategory.Children;
            ViewData["RaceCategory"] = raceCategory.Children;
            ViewData["ReligionCategory"] = religionCategory.Children;
            ViewData["Nationality"] = country;

            iSISModel.Teacher teacher;
            if (id > 0)
            {
                teacher = base.Context.PersistenceSession
                                 .QueryOver<iSISModel.Teacher>()
                                 .Where(t => t.ID == id)
                                 .SingleOrDefault();
            }
            else
            {
                teacher = new iSISModel.Teacher();
                teacher.Person = new iSISModel.Person();
            }

            TempData["Teacher"] = teacher;

            return teacher;
        }

        private void CreateOrUpdateTeacher(int id, iSISModel.Teacher teacher, FormCollection collection)
        {
            iSISModel.HierarchicalCategory bloodGroup = getHierarchicalCategory(int.Parse(collection["ComboBoxBloodGroup_VI"]));
            iSISModel.Country citizenOf = ModelsRepository.GetCountryByID(collection["ComboBoxNationality_VI"]);
            iSISModel.HierarchicalCategory gender = getHierarchicalCategory(int.Parse(collection["ComboBoxGender_VI"]));
            iSISModel.HierarchicalCategory race = getHierarchicalCategory(int.Parse(collection["ComboBoxRace_VI"]));
            iSISModel.HierarchicalCategory religion = getHierarchicalCategory(int.Parse(collection["ComboBoxReligion_VI"]));
            iSISModel.Teacher update;
            if (id > 0)
            {
                update = base.Context.PersistenceSession
                                .QueryOver<iSISModel.Teacher>()
                                .Where(t => t.ID == id)
                                .SingleOrDefault();
            }
            else
            {
                update = new iSISModel.Teacher();
                update.Person = new iSISModel.Person();
            }

            iSISModel.Teacher teacherUpdate = (iSISModel.Teacher)TempData["Teacher"];
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    update.Person.OfficialIDNo = teacher.Person.OfficialIDNo;
                    if (id > 0)
                    {
                        update.Person.CurrentName.Prefix.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "Prefix"));
                        update.Person.CurrentName.FirstName.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "FirstName"));
                        update.Person.CurrentName.MiddleName.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "MiddleName"));
                        update.Person.CurrentName.LastName.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "LastName"));
                    }
                    else
                    {
                        update.Person.CurrentName = new iSISModel.PersonName
                        {
                            Prefix = ModelsRepository.GetTextBoxMultiLanguages(collection, "Prefix"),
                            FirstName = ModelsRepository.GetTextBoxMultiLanguages(collection, "FirstName"),
                            MiddleName = ModelsRepository.GetTextBoxMultiLanguages(collection, "MiddleName"),
                            LastName = ModelsRepository.GetTextBoxMultiLanguages(collection, "LastName")
                        };
                        update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                        update.School = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
                    }
                    update.Person.BloodGroup = bloodGroup;
                    update.Person.CitizenOf = citizenOf;
                    update.Person.EmailAddress = teacher.Person.EmailAddress;
                    update.Person.Gender = gender;
                    update.Person.HomePhoneNo = teacher.Person.HomePhoneNo;
                    update.Person.MobilePhoneNo = teacher.Person.MobilePhoneNo;
                    update.Person.Race = race;
                    update.Person.Religion = religion;
                    update.Person.BirthDate = teacher.Person.BirthDate;
                    update.Person.Experiences = teacherUpdate.Person.Experiences.Where(x => x.ID > 0).ToList();
                    foreach (iSISModel.Experience item in teacherUpdate.Person.Experiences.Where(x => x.ID < 0).ToList())
                    {
                        update.Person.Experiences.Add(new Experience
                        {
                            EffectivePeriod = item.EffectivePeriod,
                            OrganizationName = item.OrganizationName,
                            OrganizationAddress = item.OrganizationAddress,
                            JobDescription = item.JobDescription
                        });
                    }
                    update.Person.Educations = teacherUpdate.Person.Educations.Where(x => x.ID > 0).ToList();
                    foreach (iSISModel.Education item in teacherUpdate.Person.Educations.Where(x => x.ID < 0).ToList())
                    {
                        update.Person.Educations.Add(new Education
                        {
                            EffectivePeriod = item.EffectivePeriod,
                            EducationLevel = item.EducationLevel,
                            AcademicInstituteName = item.AcademicInstituteName,
                            AcademicInstituteAddress = item.AcademicInstituteAddress,
                            DegreeTitle = item.DegreeTitle,
                            ShortDegreeTitle = item.ShortDegreeTitle
                        });
                    }
                    update.Person.RoyalDecorations = teacherUpdate.Person.RoyalDecorations.Where(x => x.ID > 0).ToList();
                    foreach (iSISModel.RoyalDecoration item in teacherUpdate.Person.RoyalDecorations.Where(x => x.ID < 0).ToList())
                    {
                        update.Person.RoyalDecorations.Add(new RoyalDecoration
                        {
                            EffectivePeriod = item.EffectivePeriod,
                            RoyalDecorationCategory = item.RoyalDecorationCategory
                        });
                    }

                    IList<iSISModel.HierarchicalCategory> addressCategory = (IList<iSISModel.HierarchicalCategory>)CacheManager.GetCache(CacheManager.CacheName.AddressCategory);
                    if (addressCategory.Count > 0)
                    {
                        foreach (iSISModel.HierarchicalCategory item in addressCategory[0].Children)
                        {
                            int addressID = int.Parse(collection[item.Code + "_ID"]);
                            if (addressID == 0)
                            {
                                update.Person.Addresses.Add
                                (
                                    new iSISModel.PartyAddress
                                    {
                                        Category = item,
                                        Party = update.Person,
                                        EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today),
                                        Address = new iSISModel.GeographicAddress 
                                        {
                                            AddressNo = ModelsRepository.GetTextBoxMultiLanguages(collection, item.Code + "_AddressNo"),
                                            Street1 = ModelsRepository.GetTextBoxMultiLanguages(collection, item.Code + "_Street1"),
                                            Street2 = ModelsRepository.GetTextBoxMultiLanguages(collection, item.Code + "_Street2"),
                                            Province = ModelsRepository.GetGeographicRegionByID(collection[item.Code + "_ComboBoxProvince_VI"]),
                                            District = ModelsRepository.GetGeographicRegionByID(collection[item.Code + "_ComboBoxDistrict_VI"]),
                                            Subdistrict = ModelsRepository.GetGeographicRegionByID(collection[item.Code + "_ComboBoxSubdistrict_VI"]),
                                            Country = ModelsRepository.GetCountryByID(collection[item.Code + "_ComboBoxCountry_VI"]),
                                            PostalCode = collection[item.Code + "_PostalCode"]
                                        }
                                    }
                                );
                            }
                            else
                            {
                                for (int index = 0; index < update.Person.Addresses.Count; index++)
                                {
                                    if (update.Person.Addresses[index].ID == addressID)
                                    {
                                        update.Person.Addresses[index].Address.AddressNo = ModelsRepository.GetTextBoxMultiLanguages(collection, item.Code + "_AddressNo");
                                        update.Person.Addresses[index].Address.Street1 = ModelsRepository.GetTextBoxMultiLanguages(collection, item.Code + "_Street1");
                                        update.Person.Addresses[index].Address.Street2 = ModelsRepository.GetTextBoxMultiLanguages(collection, item.Code + "_Street2");
                                        update.Person.Addresses[index].Address.Province = ModelsRepository.GetGeographicRegionByID(collection[item.Code + "_ComboBoxProvince_VI"]);
                                        update.Person.Addresses[index].Address.District = ModelsRepository.GetGeographicRegionByID(collection[item.Code + "_ComboBoxDistrict_VI"]);
                                        update.Person.Addresses[index].Address.Subdistrict = ModelsRepository.GetGeographicRegionByID(collection[item.Code + "_ComboBoxSubdistrict_VI"]);
                                        update.Person.Addresses[index].Address.Country = ModelsRepository.GetCountryByID(collection[item.Code + "_ComboBoxCountry_VI"]);
                                        update.Person.Addresses[index].Address.PostalCode = collection[item.Code + "_PostalCode"];
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    update.Persist(base.Context);

                    tran.Commit();

                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
        }

        private iSISModel.HierarchicalCategory getHierarchicalCategory(int id)
        {
            iSISModel.HierarchicalCategory result = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(x => x.ID == id)
                                               .SingleOrDefault();
            return result;
        }
    }
}