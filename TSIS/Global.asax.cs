using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using iSISModel;
using TSIS.Models;
using TSIS.Classes;

namespace TSIS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AuthConfig.RegisterAuth();
            
            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();

            DevExpress.Web.ASPxWebControl.CallbackError += Application_Error;

            WebSessionContext context = new WebSessionContext();
            IList<iSISModel.Language> language = context.PersistenceSession
                                .QueryOver<iSISModel.Language>()
                                .OrderBy(i => i.SeqNo).Asc
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.Language, language);

            IList<iSISModel.ClassLevel> classLevel = context.PersistenceSession
                                .QueryOver<iSISModel.ClassLevel>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .OrderBy(x => x.LevelNo).Asc
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.ClassLevel, classLevel);

            IList<iSISModel.GradingSystem> gradingSystem = context.PersistenceSession
                                .QueryOver<iSISModel.GradingSystem>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.GradingSystem, gradingSystem);

            IList<iSISModel.Course> course = context.PersistenceSession
                                .QueryOver<iSISModel.Course>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.Course, course);

            IList<iSISModel.Country> country = context.PersistenceSession
                                               .QueryOver<iSISModel.Country>()
                                               .List();
            CacheManager.SetCache(CacheManager.CacheName.Country, country);

            IList<iSISModel.GeographicRegion> geographicRegion = context.PersistenceSession
                                               .QueryOver<iSISModel.GeographicRegion>()
                                               .List();
            CacheManager.SetCache(CacheManager.CacheName.GeographicRegion, geographicRegion);

            IList<iSISModel.HierarchicalCategory> label = context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "Label").And(l => l.Parent == null)
                                               .List();
            CacheManager.SetCache(CacheManager.CacheName.Label, label);

            IList<iSISModel.HierarchicalCategory> addressCategory = context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(a => a.Code == "AddressCategory").And(a => a.Parent == null)
                                               .List();
            CacheManager.SetCache(CacheManager.CacheName.AddressCategory, addressCategory);

            IList<iSISModel.PhysicalRoom> room = context.PersistenceSession
                                .QueryOver<iSISModel.PhysicalRoom>()
                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.Room, room);

            iSISModel.CurriculumFramework curriculumFramework = context.PersistenceSession
                                           .QueryOver<iSISModel.CurriculumFramework>()
                                           .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                           .Take(1).SingleOrDefault();
            CacheManager.SetCache(CacheManager.CacheName.CurriculumFramework, curriculumFramework);

            iSISModel.HierarchicalCategory bloodGroup = context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "BloodGroup").And(l => l.Parent == null)
                                               .SingleOrDefault();
            CacheManager.SetCache(CacheManager.CacheName.BloodGroup, bloodGroup);

            iSISModel.HierarchicalCategory genderCategory = context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "GenderCategory").And(l => l.Parent == null)
                                               .SingleOrDefault();
            CacheManager.SetCache(CacheManager.CacheName.GenderCategory, genderCategory);

            iSISModel.HierarchicalCategory raceCategory = context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "RaceCategory").And(l => l.Parent == null)
                                               .SingleOrDefault();
            CacheManager.SetCache(CacheManager.CacheName.RaceCategory, raceCategory);

            iSISModel.HierarchicalCategory religionCategory = context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "ReligionCategory").And(l => l.Parent == null)
                                               .SingleOrDefault();
            CacheManager.SetCache(CacheManager.CacheName.ReligionCategory, religionCategory);

            iSISModel.HierarchicalCategory majorCategory = context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "Major").And(l => l.Parent == null)
                                               .SingleOrDefault();
            CacheManager.SetCache(CacheManager.CacheName.MajorCategory, majorCategory);

            iSISModel.HierarchicalCategory PPRCategory = context.PersistenceSession
                                               .QueryOver<iSISModel.HierarchicalCategory>()
                                               .Where(l => l.Code == "PPRCategory").And(l => l.Parent == null)
                                               .SingleOrDefault();
            CacheManager.SetCache(CacheManager.CacheName.PPRCategory, PPRCategory);
        }

        protected void Application_Error(object sender, EventArgs e) 
        {
            Exception exception = System.Web.HttpContext.Current.Server.GetLastError();
            //TODO: Handle Exception
        }
    }
}