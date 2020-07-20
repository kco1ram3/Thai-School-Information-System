using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iSISModel;
using System.Web.Mvc;
using iSISDemo.Classes;

namespace iSISDemo.Models
{
    public class ModelsRepository
    {
        #region GetModules
        public static IList<iSISModel.Module> GetModules()
        {
            /*
            IList<Modules> result = new List<Modules>();
            Modules m1 = new Modules
            {
                Code = "TeacherModule",
                Name = "Teachers",
                Text = new MultilingualString("en-US", "Teachers", "th-TH", "อาจารย์"),
                NavigateUrl = "~/Teachers",
                Nodes = new List<Screens>
                {
                    new Screens
                    {
                        Code = "Language",
                        Name = "root",
                        Text = new MultilingualString("en-US", "Language", "th-TH", "ภาษา"),
                        Target = "",
                        NavigateUrl = "",
                        ImageUrl = "",
                        Nodes = new List<Screens>
                        {
                            new Screens
                            {
                                Code = "LanguageSetup",
                                Name = "root",
                                Text = new MultilingualString("en-US", "Language Setup", "th-TH", "ตั้งค่าภาษา"),
                                Target = "",
                                NavigateUrl = "~/Language",
                                ImageUrl = ""
                            },
                            new Screens
                            {
                                Code = "LabelSetup",
                                Name = "root",
                                Text = new MultilingualString("en-US", "Label Setup", "th-TH", "ตั้งค่าข้อความ"),
                                Target = "",
                                NavigateUrl = "~/Language/Labels",
                                ImageUrl = ""
                            },
                        }
                    },
                    new Screens
                    {
                        Code = "CourseData",
                        Name = "root",
                        Text = new MultilingualString("en-US", "Course Data", "th-TH", "ข้อมูลรายวิชา"),
                        Target = "",
                        NavigateUrl = "~/Course",
                        ImageUrl = ""
                    },
                    new Screens
                    {
                        Code = "ClassLevelData",
                        Name = "root",
                        Text = new MultilingualString("en-US", "Class Level Data", "th-TH", "ข้อมูลระดับชั้น"),
                        Target = "",
                        NavigateUrl = "~/ClassLevel",
                        ImageUrl = ""
                    },
                    new Screens
                    {
                        Code = "SemesterData",
                        Name = "root",
                        Text = new MultilingualString("en-US", "Semester Data", "th-TH", "ข้อมูลภาคการศึกษา"),
                        Target = "",
                        NavigateUrl = "~/Semester",
                        ImageUrl = ""
                    },
                    new Screens
                    {
                        Code = "RoomData",
                        Name = "root",
                        Text = new MultilingualString("en-US", "Room Data", "th-TH", "ข้อมูลห้องเรียน"),
                        Target = "",
                        NavigateUrl = "~/Room",
                        ImageUrl = ""
                    },
                    new Screens
                    {
                        Code = "TeachersData",
                        Name = "root",
                        Text = new MultilingualString("en-US", "Teachers Data", "th-TH", "ข้อมูลอาจารย์"),
                        Target = "",
                        NavigateUrl = "~/Teachers/TeachersDetail",
                        ImageUrl = ""
                    },
                    new Screens
                    {
                        Code = "AppraisalData",
                        Name = "root",
                        Text = new MultilingualString("en-US", "Appraisal Data", "th-TH", "ข้อมูลการประเมินคะแนน"),
                        Target = "",
                        NavigateUrl = "~/Teachers/Appraisal",
                        ImageUrl = ""
                    }
                }
            };
            result.Add(m1);
            return result;
            */

            WebSessionContext context = new WebSessionContext();
            IList<iSISModel.Module> module = context.PersistenceSession
                                .QueryOver<iSISModel.Module>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today) 
                                .And(x => x.Parent == null)
                                .OrderBy(x => x.SeqNo).Asc
                                .List();

            return module;
        }
        #endregion

        #region GetModulesByID
        public static iSISModel.Module GetModulesByID(long moduleID)
        {
            /*
            IList<Modules> modules = GetModules();
            return modules.ToList().Where(m => m.Name == ModuleName).ToList();
            */
            WebSessionContext context = new WebSessionContext();
            iSISModel.Module module = context.PersistenceSession
                                .QueryOver<iSISModel.Module>()
                                .Where(x => x.ID == moduleID)
                                .SingleOrDefault();
            return module;
        }
        #endregion

        #region GetScreensByModuleID
        public static IList<iSISModel.Screen> GetScreensByModuleID(long moduleID)
        {
            /*
            IList<Modules> modules = GetModules();
            var screens = from m in modules.ToList() where m.Name == ModulesName select m.Nodes;
            return screens.SingleOrDefault();
            */
            WebSessionContext context = new WebSessionContext();
            IList<iSISModel.Screen> screen = context.PersistenceSession
                                .QueryOver<iSISModel.Screen>()
                                .Where(x => x.Module.ID == moduleID)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .And(x => x.Parent == null)
                                .OrderBy(x => x.SeqNo).Asc
                                .List();
            return screen;
        }
        #endregion

        #region GetLabel
        public static string GetLabel(string labelCode)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            IList<iSISModel.HierarchicalCategory> label = (IList<iSISModel.HierarchicalCategory>)CacheManager.GetCache(CacheManager.CacheName.Label);
            string result = null;

            if (label.Count > 0)
            {
                HierarchicalCategory title = (from n in label[0].Children
                                              where n.Code == labelCode
                                              select n).SingleOrDefault();

                try
                {
                    /*
                    result = (from n in title.Title.Values
                              where n.LanguageCode == languageCode
                              select n.Value).First().ToString();
                    */
                    result = title.Title.GetValue(languageCode);
                }
                catch (Exception ex)
                {

                }
            }

            if (result == null || result.Equals(""))
            {
                result = "[" + labelCode + "]";
            }

            return result;
        }
        #endregion

        #region GetComboBoxItems
        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.HierarchicalCategory> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.HierarchicalCategory item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Title.GetValue(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.Country> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.Country item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Title.GetValue(languageCode), item.Alpha3Code));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.GeographicRegion> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.GeographicRegion item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Title.GetValue(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.ClassLevel> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.ClassLevel item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Title.GetValue(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.GradingSystem> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.GradingSystem item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Title.GetValue(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.Role> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.Role item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Title.GetValue(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.Teacher> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.Teacher item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Person.CurrentName.ToString(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.Student> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.Student item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Person.CurrentName.ToString(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.Course> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.Course item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.CourseNo.GetValue(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        public static List<ComboBoxItems> GetComboBoxItems(IList<iSISModel.DesiredOutcome> Items)
        {
            string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
            List<ComboBoxItems> ComboboxItems = new List<ComboBoxItems>();
            if (Items != null)
            {
                foreach (iSISModel.DesiredOutcome item in Items)
                {
                    ComboboxItems.Add(new ComboBoxItems(item.Title.GetValue(languageCode), item.ID.ToString()));
                }
            }
            return ComboboxItems;
        }

        #endregion

        #region GetTextBoxMultiLanguages
        public static iSISModel.MultilingualString GetTextBoxMultiLanguages(FormCollection collection, string name)
        {
            IList<iSISModel.Language> language = (IList<iSISModel.Language>)CacheManager.GetCache(CacheManager.CacheName.Language);
            List<string> list = new List<string>();
            foreach (iSISModel.Language item in language)
            {
                list.Add(item.Code);
                list.Add(collection[name + "_" + item.Code]);
            }
            return new iSISModel.MultilingualString(list.ToArray()); 
        }
        #endregion

        #region GetCountryByID
        public static iSISModel.Country GetCountryByID(string id)
        {
            IList<iSISModel.Country> country = (IList<iSISModel.Country>)CacheManager.GetCache(CacheManager.CacheName.Country);
            return country.FirstOrDefault(x => x.Alpha3Code == id);
        }
        #endregion

        #region GetRootGeographicRegion
        public static IList<iSISModel.GeographicRegion> GetRootGeographicRegion(string CountryID)
        {
            IList<iSISModel.GeographicRegion> geographicRegion = (IList<iSISModel.GeographicRegion>)CacheManager.GetCache(CacheManager.CacheName.GeographicRegion);
            return (IList<iSISModel.GeographicRegion>)geographicRegion.Where(x => x.Parent == null && x.Country.Alpha3Code == CountryID).ToList();
        }
        #endregion

        #region GetGeographicRegion
        public static IList<iSISModel.GeographicRegion> GetGeographicRegion(int ParentID)
        {
            IList<iSISModel.GeographicRegion> geographicRegion = (IList<iSISModel.GeographicRegion>)CacheManager.GetCache(CacheManager.CacheName.GeographicRegion);
            GeographicRegion parent = geographicRegion.FirstOrDefault(x => x.ID == ParentID);
            IList<GeographicRegion> result = geographicRegion.Where(x => x.Parent == parent && x.Parent != null).ToList();
            return result;
        }
        #endregion

        #region GetGeographicRegionByID
        public static iSISModel.GeographicRegion GetGeographicRegionByID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "0";
            }
            IList<iSISModel.GeographicRegion> geographicRegion = (IList<iSISModel.GeographicRegion>)CacheManager.GetCache(CacheManager.CacheName.GeographicRegion);
            return geographicRegion.FirstOrDefault(x => x.ID == int.Parse(id));
        }
        #endregion
                                   
        #region GetClassLevelByID
        public static iSISModel.ClassLevel GetClassLevelByID(Int64 id)
        {
            IList<iSISModel.ClassLevel> classLevel = (IList<iSISModel.ClassLevel>)CacheManager.GetCache(CacheManager.CacheName.ClassLevel);
            return classLevel.FirstOrDefault(x => x.ID == id);
        }
        #endregion

        #region GetCourseByID
        public static iSISModel.Course GetCourseByID(Int64 id)
        {
            IList<iSISModel.Course> course = (IList<iSISModel.Course>)CacheManager.GetCache(CacheManager.CacheName.Course);
            return course.FirstOrDefault(x => x.ID == id);
        }
        #endregion

        #region GetRoomByID
        public static iSISModel.PhysicalRoom GetRoomByID(Int64 id)
        {
            IList<iSISModel.PhysicalRoom> physicalRoom = (IList<iSISModel.PhysicalRoom>)CacheManager.GetCache(CacheManager.CacheName.Room);
            return physicalRoom.FirstOrDefault(x => x.ID == id);
        }
        #endregion

        #region GetTeacherByID
        public static iSISModel.Teacher GetTeacherByID(Int64 id)
        {
            WebSessionContext context = new WebSessionContext();
            iSISModel.Teacher teacher = context.PersistenceSession
                                .QueryOver<iSISModel.Teacher>()
                                .Where(x => x.ID == id)
                                .SingleOrDefault();

            return teacher;
        }
        #endregion

        #region GetStudentByID
        public static iSISModel.Student GetStudentByID(Int64 id)
        {
            WebSessionContext context = new WebSessionContext();
            iSISModel.Student student = context.PersistenceSession
                                .QueryOver<iSISModel.Student>()
                                .Where(x => x.ID == id)
                                .SingleOrDefault();

            return student;
        }
        #endregion

        #region GetGradingSystemByID
        public static iSISModel.GradingSystem GetGradingSystemByID(int id)
        {
            IList<iSISModel.GradingSystem> gradingSystem = (IList<iSISModel.GradingSystem>)CacheManager.GetCache(CacheManager.CacheName.GradingSystem);
            return gradingSystem.FirstOrDefault(x => x.ID == id);
        }
        #endregion
    }
}