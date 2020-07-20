using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web;
using NHibernate;
using TSIS.Controllers;
using TSIS.Models;
using iSISModel;
using DevExpress.Web.Mvc;
using System.Threading;
using TSIS.Filters;
using TSIS.Classes;

namespace TSIS.Areas.Student.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class StudentInfoController : BaseController
    {
        // GET: Student/StudentInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentList()
        {
            return PartialView("~/Areas/Student/Views/StudentInfo/_StudentList.cshtml", getStudentList());
        }
        public ActionResult StudentImages()
        {
            if (DevExpressHelper.IsCallback)
                // Intentionally pauses server-side processing,
                // to demonstrate the Loading Panel functionality.
                Thread.Sleep(500);
            int StudentID = !string.IsNullOrEmpty(Request.Params["StudentID"]) ? int.Parse(Request.Params["StudentID"]) : 1;
            TempData["StudentID"] = StudentID;
            return PartialView("~/Areas/Student/Views/StudentInfo/_StudentImages.cshtml", getStudent(StudentID));
        }

        [HttpPost]
        public ActionResult StudentUploadImages(UploadedFile[] ucMultiFile)
        {
            var StudentID = (int)TempData["StudentID"];

            if (Request.Params["btnSave"] != null)
            {
                if (ucMultiFile != null)
                {
                    string[] imageContentType = { "image/gif", "image/jpeg", "image/pjpeg", "image/png" };
                    double maximumFileSize = (2 * 1024f) * 1024f;
                    iSISModel.Student student = base.Context.PersistenceSession
                                                       .QueryOver<iSISModel.Student>()
                                                       .Where(s => s.ID == StudentID)
                                                       .SingleOrDefault();
                    using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                    {
                        try
                        {
                            for (int index = 0; index < ucMultiFile.Length; index++)
                            {
                                if (ucMultiFile[index].FileBytes.Length > 0 && ucMultiFile[index].IsValid && imageContentType.Contains(ucMultiFile[index].ContentType) && ucMultiFile[index].ContentLength <= maximumFileSize)
                                {
                                    System.Drawing.Image original = System.Drawing.Image.FromStream(ucMultiFile[index].FileContent);
                                    ImageConverter converter = new ImageConverter();
                                    student.Person.Photos.Add(new Photo
                                    {
                                        Image = (byte[])converter.ConvertTo(original, typeof(byte[])),
                                        Date = DateTime.Now
                                    });
                                }
                            }
                            student.Persist(base.Context);

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
            return RedirectToAction("Index");
        }

        public ActionResult StudentDeleteImage(int id, int image_id)
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
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View("StudentUpdate", getStudent());
        }
        public ActionResult Update(int id)
        {
            return View("StudentUpdate", getStudent(id));
        }
        [HttpPost]
        public ActionResult Update(int? id, iSISModel.Student student, UploadedFile[] ucMultiFile, FormCollection collection)
        {
            if (id > 0)
            {
                student = base.Context.PersistenceSession
                            .QueryOver<iSISModel.Student>()
                            .Where(s => s.ID == id)
                            .SingleOrDefault();
            }
            else
            {
                student = new iSISModel.Student()
                {
                    Person = new iSISModel.Person()
                    {
                        CurrentName = new iSISModel.PersonName()
                        {
                            EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today)
                        }
                    },
                    EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today)
                };
            }
            // Student
            string studentIDNo = (!string.IsNullOrEmpty(collection["TextBoxStudentIDNo"])) ? collection["TextBoxStudentIDNo"].ToString() : string.Empty;
            iSISModel.HierarchicalCategory major = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxMajorGroup_VI"]) ? int.Parse(collection["ComboBoxMajorGroup_VI"]) : (-1));
            iSISModel.ClassLevel admittedClassLevel = ModelsRepository.GetClassLevelByID(!string.IsNullOrEmpty(collection["ComboBoxAdmittedClassLevel_VI"]) ? Int64.Parse(collection["ComboBoxAdmittedClassLevel_VI"]) : (-1));
            Int64 admittedSemester = (!string.IsNullOrEmpty(collection["ComboBoxAdmittedAcademicYear_VI"])) ? Int64.Parse(collection["ComboBoxAdmittedAcademicYear_VI"]) : 0;
            float admittedGPA = (!string.IsNullOrEmpty(collection["SpinEditAdmittedGPA"].ToString())) ? float.Parse(collection["SpinEditAdmittedGPA"]) : (float)0.00;
            float currentGPA = (!string.IsNullOrEmpty(collection["SpinEditCurrentGPA"].ToString())) ? float.Parse(collection["SpinEditCurrentGPA"]) : (float)0.00;

            iSISModel.School school = Context.CurrentSchool;
            iSISModel.Country studentCitizenOf = ModelsRepository.GetCountryByID(collection["ComboBoxNationalityStudent_VI"]);
            iSISModel.MultilingualString studentPrefix = ModelsRepository.GetTextBoxMultiLanguages(collection, "PrefixStudent");
            iSISModel.MultilingualString studentFirstName = ModelsRepository.GetTextBoxMultiLanguages(collection, "FirstNameStudent");
            iSISModel.MultilingualString studentLastName = ModelsRepository.GetTextBoxMultiLanguages(collection, "LastNameStudent");
            iSISModel.MultilingualString studentMiddleName = ModelsRepository.GetTextBoxMultiLanguages(collection, "MiddleNameStudent");
            iSISModel.HierarchicalCategory studentBloodGroup = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxBloodGroupStudent_VI"]) ? int.Parse(collection["ComboBoxBloodGroupStudent_VI"]) : (-1));
            iSISModel.HierarchicalCategory studentGender = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxGenderStudent_VI"]) ? int.Parse(collection["ComboBoxGenderStudent_VI"]) : (-1));
            iSISModel.HierarchicalCategory studentRace = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxRaceStudent_VI"]) ? int.Parse(collection["ComboBoxRaceStudent_VI"]) : (-1));
            iSISModel.HierarchicalCategory studentReligion = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxReligionStudent_VI"]) ? int.Parse(collection["ComboBoxReligionStudent_VI"]) : (-1));
            DateTime studentBirthdate = (!string.IsNullOrEmpty(collection["DateEditBirthdayStudent"])) ? DateTime.ParseExact(collection["DateEditBirthdayStudent"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            string studentHomePhoneNo = (!string.IsNullOrEmpty(collection["TextBoxHomePhoneNoStudent"])) ? collection["TextBoxHomePhoneNoStudent"].ToString() : string.Empty;
            string studentMobilePhoneNo = (!string.IsNullOrEmpty(collection["TextBoxMobilePhoneNoStudent"])) ? collection["TextBoxMobilePhoneNoStudent"].ToString() : string.Empty;
            string studentEmail = (!string.IsNullOrEmpty(collection["TextBoxEmailStudent"])) ? collection["TextBoxEmailStudent"].ToString() : string.Empty;
            // Fahter
            iSISModel.Country fatherCitizenOf = ModelsRepository.GetCountryByID(collection["ComboBoxNationalityFather_VI"]);
            iSISModel.MultilingualString fatherPrefix = ModelsRepository.GetTextBoxMultiLanguages(collection, "PrefixFather");
            iSISModel.MultilingualString fatherFirstName = ModelsRepository.GetTextBoxMultiLanguages(collection, "FirstNameFather");
            iSISModel.MultilingualString fatherLastName = ModelsRepository.GetTextBoxMultiLanguages(collection, "LastNameFather");
            iSISModel.MultilingualString fatherMiddleName = ModelsRepository.GetTextBoxMultiLanguages(collection, "MiddleNameFather");
            iSISModel.HierarchicalCategory fatherBloodGroup = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxBloodGroupFather_VI"]) ? int.Parse(collection["ComboBoxBloodGroupFather_VI"]) : (-1));
            iSISModel.HierarchicalCategory fatherGender = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxGenderFather_VI"]) ? int.Parse(collection["ComboBoxGenderFather_VI"]) : (-1));
            iSISModel.HierarchicalCategory fatherRace = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxRaceFather_VI"]) ? int.Parse(collection["ComboBoxRaceFather_VI"]) : (-1));
            iSISModel.HierarchicalCategory fatherReligion = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxReligionFather_VI"]) ? int.Parse(collection["ComboBoxReligionFather_VI"]) : (-1));
            DateTime fatherBirthdate = (!string.IsNullOrEmpty(collection["DateEditBirthdayFather"])) ? DateTime.ParseExact(collection["DateEditBirthdayFather"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            string fatherHomePhoneNo = (!string.IsNullOrEmpty(collection["TextBoxHomePhoneNoFather"])) ? collection["TextBoxHomePhoneNoFather"].ToString() : string.Empty;
            string fatherMobilePhoneNo = (!string.IsNullOrEmpty(collection["TextBoxMobilePhoneNoFather"])) ? collection["TextBoxMobilePhoneNoFather"].ToString() : string.Empty;
            string fatherEmail = (!string.IsNullOrEmpty(collection["TextBoxEmailFather"])) ? collection["TextBoxEmailFather"].ToString() : string.Empty;
            // Mother
            iSISModel.Country motherCitizenOf = ModelsRepository.GetCountryByID(collection["ComboBoxNationalityMother_VI"]);
            iSISModel.MultilingualString motherPrefix = ModelsRepository.GetTextBoxMultiLanguages(collection, "PrefixMother");
            iSISModel.MultilingualString motherFirstName = ModelsRepository.GetTextBoxMultiLanguages(collection, "FirstNameMother");
            iSISModel.MultilingualString motherLastName = ModelsRepository.GetTextBoxMultiLanguages(collection, "LastNameMother");
            iSISModel.MultilingualString motherMiddleName = ModelsRepository.GetTextBoxMultiLanguages(collection, "MiddleNameMother");
            iSISModel.HierarchicalCategory motherBloodGroup = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxBloodGroupMother_VI"]) ? int.Parse(collection["ComboBoxBloodGroupMother_VI"]) : (-1));
            iSISModel.HierarchicalCategory motherGender = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxGenderMother_VI"]) ? int.Parse(collection["ComboBoxGenderMother_VI"]) : (-1));
            iSISModel.HierarchicalCategory motherRace = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxRaceMother_VI"]) ? int.Parse(collection["ComboBoxRaceMother_VI"]) : (-1));
            iSISModel.HierarchicalCategory motherReligion = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxReligionMother_VI"]) ? int.Parse(collection["ComboBoxReligionMother_VI"]) : (-1));
            DateTime motherBirthdate = (!string.IsNullOrEmpty(collection["DateEditBirthdayMother"])) ? DateTime.ParseExact(collection["DateEditBirthdayMother"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            string motherHomePhoneNo = (!string.IsNullOrEmpty(collection["TextBoxHomePhoneNoMother"])) ? collection["TextBoxHomePhoneNoMother"].ToString() : string.Empty;
            string motherMobilePhoneNo = (!string.IsNullOrEmpty(collection["TextBoxMobilePhoneNoMother"])) ? collection["TextBoxMobilePhoneNoMother"].ToString() : string.Empty;
            string motherEmail = (!string.IsNullOrEmpty(collection["TextBoxEmailMother"])) ? collection["TextBoxEmailMother"].ToString() : string.Empty;
            // Guardian
            iSISModel.Country guardianCitizenOf = ModelsRepository.GetCountryByID(collection["ComboBoxNationalityGuardian_VI"]);
            iSISModel.MultilingualString guardianPrefix = ModelsRepository.GetTextBoxMultiLanguages(collection, "PrefixGuardian");
            iSISModel.MultilingualString guardianFirstName = ModelsRepository.GetTextBoxMultiLanguages(collection, "FirstNameGuardian");
            iSISModel.MultilingualString guardianLastName = ModelsRepository.GetTextBoxMultiLanguages(collection, "LastNameGuardian");
            iSISModel.MultilingualString guardianMiddleName = ModelsRepository.GetTextBoxMultiLanguages(collection, "MiddleNameGuardian");
            iSISModel.HierarchicalCategory guardianBloodGroup = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxBloodGroupGuardian_VI"]) ? int.Parse(collection["ComboBoxBloodGroupGuardian_VI"]) : (-1));
            iSISModel.HierarchicalCategory guardianGender = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxGenderGuardian_VI"]) ? int.Parse(collection["ComboBoxGenderGuardian_VI"]) : (-1));
            iSISModel.HierarchicalCategory guardianRace = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxRaceGuardian_VI"]) ? int.Parse(collection["ComboBoxRaceGuardian_VI"]) : (-1));
            iSISModel.HierarchicalCategory guardianReligion = CategoryById(!string.IsNullOrEmpty(collection["ComboBoxReligionGuardian_VI"]) ? int.Parse(collection["ComboBoxReligionGuardian_VI"]) : (-1));
            DateTime guardianBirthdate = (!string.IsNullOrEmpty(collection["DateEditBirthdayGuardian"])) ? DateTime.ParseExact(collection["DateEditBirthdayGuardian"], "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Today;
            string guardianHomePhoneNo = (!string.IsNullOrEmpty(collection["TextBoxHomePhoneNoGuardian"])) ? collection["TextBoxHomePhoneNoGuardian"].ToString() : string.Empty;
            string guardianMobilePhoneNo = (!string.IsNullOrEmpty(collection["TextBoxMobilePhoneNoGuardian"])) ? collection["TextBoxMobilePhoneNoGuardian"].ToString() : string.Empty;
            string guardianEmail = (!string.IsNullOrEmpty(collection["TextBoxEmailGuardian"])) ? collection["TextBoxEmailGuardian"].ToString() : string.Empty;
            // Guardian
            int guardianID = RadioButtonListExtension.GetValue<int>("GuardianRadioButtonList");
            // Student
            iSISModel.Semester semester = base.Context.PersistenceSession
                                    .QueryOver<iSISModel.Semester>()
                                    .Where(s => s.ID == admittedSemester)
                                    .SingleOrDefault();

            student.Person.CitizenOf = studentCitizenOf;
            student.Person.CurrentName.Prefix = studentPrefix;
            student.Person.CurrentName.FirstName = studentFirstName;
            student.Person.CurrentName.LastName = studentLastName;
            student.Person.CurrentName.MiddleName = studentMiddleName;
            student.Person.BloodGroup = studentBloodGroup;
            student.Person.Gender = studentGender;
            student.Person.Race = studentRace;
            student.Person.Religion = studentReligion;
            student.Person.BirthDate = studentBirthdate;
            student.Person.HomePhoneNo = studentHomePhoneNo;
            student.Person.MobilePhoneNo = studentMobilePhoneNo;
            student.Person.EmailAddress = studentEmail;

            student.School = school;
            student.IDNo = studentIDNo;
            student.AdmittedSemester = semester;
            student.AdmittedAcademicYear = (semester != null) ? semester.AcademicYear : 0;
            student.AdmittedSemesterNo = (semester != null) ? semester.SemesterNo : 0;
            student.AdmittedClassLevel = admittedClassLevel;
            student.Major = major;
            student.AdmittedGPA = admittedGPA;
            student.CurrentGPA = currentGPA;
            // Father
            iSISModel.Person father = new iSISModel.Person()
            {
                CurrentName = new PersonName
                {
                    Prefix = fatherPrefix,
                    FirstName = fatherFirstName,
                    LastName = fatherLastName,
                    MiddleName = fatherMiddleName
                },
                CitizenOf = fatherCitizenOf,
                BloodGroup = fatherBloodGroup,
                Gender = fatherGender,
                Race = fatherRace,
                Religion = fatherReligion,
                BirthDate = fatherBirthdate,
                HomePhoneNo = fatherHomePhoneNo,
                MobilePhoneNo = fatherMobilePhoneNo,
                EmailAddress = fatherEmail,
            };
            // Mother
            iSISModel.Person mother = new iSISModel.Person()
            {
                CurrentName = new PersonName
                {
                    Prefix = motherPrefix,
                    FirstName = motherFirstName,
                    LastName = motherLastName,
                    MiddleName = motherMiddleName
                },
                CitizenOf = motherCitizenOf,
                BloodGroup = motherBloodGroup,
                Gender = motherGender,
                Race = motherRace,
                Religion = motherReligion,
                BirthDate = motherBirthdate,
                HomePhoneNo = motherHomePhoneNo,
                MobilePhoneNo = motherMobilePhoneNo,
                EmailAddress = motherEmail,
            };
            // Guardian
            iSISModel.Person guardian = new iSISModel.Person()
            {
                CurrentName = new PersonName
                {
                    Prefix = guardianPrefix,
                    FirstName = guardianFirstName,
                    LastName = guardianLastName,
                    MiddleName = guardianMiddleName
                },
                CitizenOf = guardianCitizenOf,
                BloodGroup = guardianBloodGroup,
                Gender = guardianGender,
                Race = guardianRace,
                Religion = guardianReligion,
                BirthDate = guardianBirthdate,
                HomePhoneNo = guardianHomePhoneNo,
                MobilePhoneNo = guardianMobilePhoneNo,
                EmailAddress = guardianEmail,
            };
            // Address Category
            IList<iSISModel.HierarchicalCategory> addresses = (IList<iSISModel.HierarchicalCategory>)CacheManager.GetCache(CacheManager.CacheName.AddressCategory);
            // Student Address
            if (addresses.Count > 0)
            {
                foreach (iSISModel.HierarchicalCategory item in addresses)
                {
                    int AddressID = !string.IsNullOrEmpty(collection["Student" + item.Code + "_ID"])
                                                        ? int.Parse(collection["Student" + item.Code + "_ID"])
                                                        : (-1);
                    if (AddressID == (-1))
                        break;

                    if (AddressID == 0)
                    {
                        student.Person.Addresses.Add
                        (
                            new iSISModel.PartyAddress
                            {
                                Category = item,
                                Party = student.Person,
                                EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today),
                                Address = new iSISModel.GeographicAddress
                                {
                                    AddressNo = ModelsRepository.GetTextBoxMultiLanguages(collection, "AddressNo" + "Student" + item.Code),
                                    Street1 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street1" + "Student" + item.Code),
                                    Street2 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street2" + "Student" + item.Code),
                                    Province = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxProvince" + "Student" + item.Code + "_VI"]),
                                    District = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxDistrict" + "Student" + item.Code + "_VI"]),
                                    Subdistrict = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxSubdistrict" + "Student" + item.Code + "_VI"]),
                                    Country = ModelsRepository.GetCountryByID(collection["ComboBoxNationality" + "Student" + item.Code + "_VI"]),
                                    PostalCode = collection["PostalCode" + "Student" + item.Code],
                                }
                            }
                        );
                    }
                    else
                    {
                        for (int index = 0; index < student.Person.Addresses.Count; index++)
                        {
                            if (student.Person.Addresses[index].ID == AddressID)
                            {
                                student.Person.Addresses[index].Address.AddressNo = ModelsRepository.GetTextBoxMultiLanguages(collection, "AddressNo" + "Student" + item.Code);
                                student.Person.Addresses[index].Address.Street1 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street1" + "Student" + item.Code);
                                student.Person.Addresses[index].Address.Street2 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street2" + "Student" + item.Code);
                                student.Person.Addresses[index].Address.Province = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxProvince" + "Student" + item.Code + "_VI"]);
                                student.Person.Addresses[index].Address.District = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxDistrict" + "Student" + item.Code + "_VI"]);
                                student.Person.Addresses[index].Address.Subdistrict = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxSubdistrict" + "Student" + item.Code + "_VI"]);
                                student.Person.Addresses[index].Address.Country = ModelsRepository.GetCountryByID(collection["ComboBoxNationality" + "Student" + item.Code + "_VI"]);
                                student.Person.Addresses[index].Address.PostalCode = collection["PostalCode" + "Student" + item.Code];
                                break;
                            }
                        }
                    }
                }
            }
            // Picture List
            if (ucMultiFile != null)
            {
                string[] imageContentType = { "image/gif", "image/jpeg", "image/pjpeg", "image/png" };
                double maximumFileSize = (2 * 1024f) * 1024f;

                for (int index = 0; index < ucMultiFile.Length; index++)
                {
                    if (ucMultiFile[index].FileBytes.Length > 0
                        && ucMultiFile[index].IsValid
                        && imageContentType.Contains(ucMultiFile[index].ContentType)
                        && ucMultiFile[index].ContentLength <= maximumFileSize)
                    {
                        System.Drawing.Image original = System.Drawing.Image.FromStream(ucMultiFile[index].FileContent);
                        ImageConverter converter = new ImageConverter();
                        student.Person.Photos.Add(new Photo
                        {
                            Image = (byte[])converter.ConvertTo(original, typeof(byte[])),
                            Date = DateTime.Now
                        });
                    }
                }
            }
            // Update Person Relationships Existing
            if (student.Person.PersonRelationships.Count > 0)
            {
                // Father
                iSISModel.InterPersonRelation fatherRelation = student.Person.GetPersonRelationByCode("Father");
                if (fatherRelation != null)
                {
                    fatherRelation.SecondaryPerson.CitizenOf = father.CitizenOf;
                    fatherRelation.SecondaryPerson.CurrentName = father.CurrentName;
                    fatherRelation.SecondaryPerson.BloodGroup = father.BloodGroup;
                    fatherRelation.SecondaryPerson.Gender = father.Gender;
                    fatherRelation.SecondaryPerson.Race = father.Race;
                    fatherRelation.SecondaryPerson.Religion = father.Religion;
                }
                // Mother
                iSISModel.InterPersonRelation motherRelation = student.Person.GetPersonRelationByCode("Mother");
                if (motherRelation != null)
                {
                    motherRelation.SecondaryPerson.CitizenOf = mother.CitizenOf;
                    motherRelation.SecondaryPerson.CurrentName = mother.CurrentName;
                    motherRelation.SecondaryPerson.BloodGroup = mother.BloodGroup;
                    motherRelation.SecondaryPerson.Gender = mother.Gender;
                    motherRelation.SecondaryPerson.Race = mother.Race;
                    motherRelation.SecondaryPerson.Religion = mother.Religion;
                }
                // Guardian
                iSISModel.InterPersonRelation guardianRelation = student.Person.GetPersonRelationByCode("Guardian");
                if (guardianRelation != null)
                {
                    // Expire Existing Guardian and Add New Guardian with the same category
                    student.Person.AddPersonRelationAfterExpiringExistingInstancesOfTheSameCategory(guardianRelation);
                    // Get current Guardian of student
                    guardianRelation = student.Person.GetPersonRelationByCode("Guardian");
                    // Get selected radio button for new Guardian
                    iSISModel.InterPersonRelation updateGuardian = student.Person.GetPersonRelationByID(guardianID);
                    // Guardian changed is Father or Mother ???
                    if (updateGuardian.Category != fatherRelation.Category && updateGuardian.Category != motherRelation.Category)
                    {
                        updateGuardian.SecondaryPerson = guardian;
                        // Address
                        foreach (iSISModel.HierarchicalCategory item in addresses)
                        {
                            updateGuardian.SecondaryPerson.Addresses.Add
                            (
                                new iSISModel.PartyAddress
                                {
                                    Category = item,
                                    Party = updateGuardian.SecondaryPerson,
                                    EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today),
                                    Address = new iSISModel.GeographicAddress
                                    {
                                        AddressNo = ModelsRepository.GetTextBoxMultiLanguages(collection, "AddressNo" + updateGuardian.Category.Code + item.Code),
                                        Street1 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street1" + updateGuardian.Category.Code + item.Code),
                                        Street2 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street2" + updateGuardian.Category.Code + item.Code),
                                        Province = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxProvince" + updateGuardian.Category.Code + item.Code + "_VI"]),
                                        District = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxDistrict" + updateGuardian.Category.Code + item.Code + "_VI"]),
                                        Subdistrict = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxSubdistrict" + updateGuardian.Category.Code + item.Code + "_VI"]),
                                        Country = ModelsRepository.GetCountryByID(collection["ComboBoxNationality" + updateGuardian.Category.Code + item.Code + "_VI"]),
                                        PostalCode = collection["PostalCode" + updateGuardian.Category.Code + item.Code],
                                    }
                                }
                            );
                        }
                    }
                    guardianRelation.SecondaryPerson = updateGuardian.SecondaryPerson;
                }
            }
            // Create New
            else
            {
                // Father Relation
                iSISModel.InterPersonRelation fatherRelation = new InterPersonRelation()
                {
                    Category = CategoryByCode("Father"),
                    PrimaryPerson = student.Person,
                    SecondaryPerson = father,
                    EffectivePeriod = new DateTimeRange(DateTime.Today),
                };
                student.Person.PersonRelationships.Add(fatherRelation);
                // Mother Relation
                iSISModel.InterPersonRelation motherRelation = new InterPersonRelation()
                {
                    Category = CategoryByCode("Mother"),
                    PrimaryPerson = student.Person,
                    SecondaryPerson = mother,
                    EffectivePeriod = new DateTimeRange(DateTime.Today),
                };
                student.Person.PersonRelationships.Add(motherRelation);
                // Guardian Relation
                if ("Father" == CategoryById(guardianID).Code)
                {
                    guardian = father;
                }
                else
                    if ("Mother" == CategoryById(guardianID).Code)
                    {
                        guardian = mother;
                    }
                iSISModel.InterPersonRelation guardianRelation = new InterPersonRelation()
                {
                    Category = CategoryByCode("Guardian"),
                    PrimaryPerson = student.Person,
                    SecondaryPerson = guardian,
                    EffectivePeriod = new DateTimeRange(DateTime.Today),
                };
                student.Person.PersonRelationships.Add(guardianRelation);
            }
            // Address of Person Relations
            foreach (iSISModel.InterPersonRelation studentRelation in student.Person.PersonRelationships)
            {
                if (studentRelation.IsEffectiveNow && addresses.Count > 0)
                {
                    foreach (iSISModel.HierarchicalCategory item in addresses)
                    {
                        int AddressID = !string.IsNullOrEmpty(collection[studentRelation.Category.Code + item.Code + "_ID"])
                                                            ? int.Parse(collection[studentRelation.Category.Code + item.Code + "_ID"])
                                                            : (-1);
                        if (AddressID == (-1))
                            break;

                        if (AddressID == 0)
                        {
                            studentRelation.SecondaryPerson.Addresses.Add
                            (
                                new iSISModel.PartyAddress
                                {
                                    Category = item,
                                    Party = studentRelation.SecondaryPerson,
                                    EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today),
                                    Address = new iSISModel.GeographicAddress
                                    {
                                        AddressNo = ModelsRepository.GetTextBoxMultiLanguages(collection, "AddressNo" + studentRelation.Category.Code + item.Code),
                                        Street1 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street1" + studentRelation.Category.Code + item.Code),
                                        Street2 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street2" + studentRelation.Category.Code + item.Code),
                                        Province = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxProvince" + studentRelation.Category.Code + item.Code + "_VI"]),
                                        District = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxDistrict" + studentRelation.Category.Code + item.Code + "_VI"]),
                                        Subdistrict = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxSubdistrict" + studentRelation.Category.Code + item.Code + "_VI"]),
                                        Country = ModelsRepository.GetCountryByID(collection["ComboBoxNationality" + studentRelation.Category.Code + item.Code + "_VI"]),
                                        PostalCode = collection["PostalCode" + studentRelation.Category.Code + item.Code],
                                    }
                                }
                            );
                        }
                        else
                        {
                            for (int index = 0; index < studentRelation.SecondaryPerson.Addresses.Count; index++)
                            {
                                if (studentRelation.SecondaryPerson.Addresses[index].ID == AddressID)
                                {
                                    studentRelation.SecondaryPerson.Addresses[index].Address.AddressNo = ModelsRepository.GetTextBoxMultiLanguages(collection, "AddressNo" + studentRelation.Category.Code + item.Code);
                                    studentRelation.SecondaryPerson.Addresses[index].Address.Street1 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street1" + studentRelation.Category.Code + item.Code);
                                    studentRelation.SecondaryPerson.Addresses[index].Address.Street2 = ModelsRepository.GetTextBoxMultiLanguages(collection, "Street2" + studentRelation.Category.Code + item.Code);
                                    studentRelation.SecondaryPerson.Addresses[index].Address.Province = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxProvince" + studentRelation.Category.Code + item.Code + "_VI"]);
                                    studentRelation.SecondaryPerson.Addresses[index].Address.District = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxDistrict" + studentRelation.Category.Code + item.Code + "_VI"]);
                                    studentRelation.SecondaryPerson.Addresses[index].Address.Subdistrict = ModelsRepository.GetGeographicRegionByID(collection["ComboBoxSubdistrict" + studentRelation.Category.Code + item.Code + "_VI"]);
                                    studentRelation.SecondaryPerson.Addresses[index].Address.Country = ModelsRepository.GetCountryByID(collection["ComboBoxNationality" + studentRelation.Category.Code + item.Code + "_VI"]);
                                    studentRelation.SecondaryPerson.Addresses[index].Address.PostalCode = collection["PostalCode" + studentRelation.Category.Code + item.Code];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    student.Persist(base.Context);
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
            iSISModel.Student student = getStudent(id);

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    student.EffectivePeriod.To = DateTime.Today;
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
        public ActionResult GuardianChanged(string personInfo, int studentID, int guardianID)
        {
            ViewData["PersonInfo"] = personInfo;

            iSISModel.Student student = getStudent(studentID);
            iSISModel.Person guardian = null;
            if (studentID == 0)
            {
                guardian = new iSISModel.Person();
            }
            else
            {
                iSISModel.InterPersonRelation guardianRelation = student.Person.GetPersonRelationByID(guardianID);
                guardian = guardianRelation != null ? guardianRelation.SecondaryPerson : new iSISModel.Person();
            }
            return PartialView("~/Views/Shared/_PersonAddress.cshtml", guardian);
        }
        private IList<iSISModel.Student> getStudentList()
        {
            iSISModel.School school = base.Context.CurrentSchool;

            IList<iSISModel.Student> students = base.Context.PersistenceSession
                .QueryOver<iSISModel.Student>()
                .Where(s => s.School == school)
                .And(s => s.EffectivePeriod.To > DateTime.Today)
                .List();

            return students;
        }
        private iSISModel.Student getStudent(int id = 0)
        {
            ViewData["Semesters"] = ModelsRepository.GetComboBoxItems(Context.CurrentSchool.Semesters.OrderBy(s => s.AcademicYear).ToList());
            ViewData["BloodGroup"] = ModelsRepository.GetComboBoxItems(((iSISModel.HierarchicalCategory)CacheManager.GetCache(CacheManager.CacheName.BloodGroup)).Children);
            ViewData["GenderCategory"] = ModelsRepository.GetComboBoxItems(((iSISModel.HierarchicalCategory)CacheManager.GetCache(CacheManager.CacheName.GenderCategory)).Children);
            ViewData["RaceCategory"] = ModelsRepository.GetComboBoxItems(((iSISModel.HierarchicalCategory)CacheManager.GetCache(CacheManager.CacheName.RaceCategory)).Children);
            ViewData["ReligionCategory"] = ModelsRepository.GetComboBoxItems(((iSISModel.HierarchicalCategory)CacheManager.GetCache(CacheManager.CacheName.ReligionCategory)).Children);
            ViewData["MajorGroup"] = ModelsRepository.GetComboBoxItems(((iSISModel.HierarchicalCategory)CacheManager.GetCache(CacheManager.CacheName.MajorCategory)).Children);
            ViewData["Nationality"] = ModelsRepository.GetComboBoxItems((IList<iSISModel.Country>)CacheManager.GetCache(CacheManager.CacheName.Country));
            ViewData["ClassLevel"] = ModelsRepository.GetComboBoxItems((IList<iSISModel.ClassLevel>)CacheManager.GetCache(CacheManager.CacheName.ClassLevel));
            ViewData["PPRelations"] = ModelsRepository.GetComboBoxItems(((iSISModel.HierarchicalCategory)CacheManager.GetCache(CacheManager.CacheName.PPRCategory)).Children);

            iSISModel.Student student = null;

            if (id == 0)
            {
                student = new iSISModel.Student()
                {
                    Person = new iSISModel.Person(),
                };
            }
            else
            {
                student = base.Context.PersistenceSession
                            .QueryOver<iSISModel.Student>()
                            .Where(a => a.ID == id)
                            .SingleOrDefault();
            }
            return student;
        }
        public virtual iSISModel.HierarchicalCategory CategoryById(int id)
        {
            return Context.PersistenceSession.QueryOver<iSISModel.HierarchicalCategory>()
                    .Where(x => x.ID == id)
                    .SingleOrDefault();
        }
        public virtual iSISModel.HierarchicalCategory CategoryByCode(string code)
        {
            return Context.PersistenceSession.QueryOver<iSISModel.HierarchicalCategory>()
                    .Where(x => x.Code == code)
                    .SingleOrDefault();
        }
    }
}