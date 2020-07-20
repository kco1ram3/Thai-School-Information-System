using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Controllers;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Controllers.Setup
{
    [UserFilterAuthorizeAttribute]
    public class ClassLevelController : BaseController
    {
        // GET: ClassLevel
        public ActionResult Index()
        {
            return View((IList<iSISModel.ClassLevel>)CacheManager.GetCache(CacheManager.CacheName.ClassLevel));
        }

        public ActionResult GridViewClassLevelData()
        {
            return PartialView("_GridViewClassLevelData", (IList<iSISModel.ClassLevel>)CacheManager.GetCache(CacheManager.CacheName.ClassLevel));
        }

        [HttpPost]
        public ActionResult GridViewClassLevelDataAddNewOrUpdate(iSISModel.ClassLevel classLevel, FormCollection collection)
        {
            iSISModel.ClassLevel update = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.ClassLevel>()
                                           .Where(x => x.ID == classLevel.ID)
                                           .SingleOrDefault();
            if (update == null)
            {
                update = new iSISModel.ClassLevel();
                update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
            }
            if (update.Title == null)
            {
                update.Title = ModelsRepository.GetTextBoxMultiLanguages(collection, "Title");
            }
            else
            {
                update.Title.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "Title"));
            }
            if (update.ShortTitle == null)
            {
                update.ShortTitle = ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle");
            }
            else
            {
                update.ShortTitle.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "ShortTitle"));
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
            SetupClassLevelSection(update);
            return PartialView("_GridViewClassLevelData", ClassLevelData());
        }

        [HttpPost]
        public ActionResult GridViewClassLevelDataDelete(long ID)
        {
            iSISModel.ClassLevel classLevel = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.ClassLevel>()
                                           .Where(x => x.ID == ID)
                                           .SingleOrDefault();

            classLevel.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    classLevel.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            SetupClassLevelSection(classLevel, true);
            return PartialView("_GridViewClassLevelData", ClassLevelData());
        }

        private IList<iSISModel.ClassLevel> ClassLevelData()
        {
            IList<iSISModel.ClassLevel> classLevel = base.Context.PersistenceSession
                                .QueryOver<iSISModel.ClassLevel>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .OrderBy(x => x.LevelNo).Asc
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.ClassLevel, classLevel);

            return classLevel;
        }

        private void SetupClassLevelSection(iSISModel.ClassLevel classLevel, bool isDelete = false)
        {
            if (isDelete)
            {
                IList<iSISModel.ClassLevelSection> classLevelSection = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevelSection>()
                                                .Where(x => x.ClassLevel == classLevel)
                                                .List();

                using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        foreach (iSISModel.ClassLevelSection i in classLevelSection)
                        {
                            i.EffectivePeriod.To = DateTime.Today;
                            i.Persist(Context);
                        }

                        tran.Commit();
                    }
                    catch (Exception exc)
                    {
                        tran.Rollback();
                        throw exc;
                    }
                }
            }
            else
            {
                iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
                IList<iSISModel.Semester> semester = base.Context.PersistenceSession
                                                    .QueryOver<iSISModel.Semester>()
                                                    .Where(x => x.School == school)
                                                    .And(x => x.EffectivePeriod.To > DateTime.Today)
                                                    .List();

                foreach (iSISModel.Semester i in semester)
                {
                    iSISModel.ClassLevelSection classLevelSection = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassLevelSection>()
                                                .Where(x => x.ClassLevel == classLevel)
                                                .And(x => x.School == school)
                                                .And(x => x.Semester == i)
                                                .SingleOrDefault();

                    if (classLevelSection == null)
                    {
                        classLevelSection = new iSISModel.ClassLevelSection();
                        classLevelSection.School = school;
                        classLevelSection.ClassLevel = classLevel;
                        classLevelSection.Semester = i;
                        classLevelSection.EffectivePeriod = classLevel.EffectivePeriod;
                        classLevelSection.Persist(base.Context);
                    }
                }
            }
        }
    }
}