using System.Web.Mvc;

namespace iSIS.Website.Areas.Teachers
{
    public class TeachersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Teachers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Teachers_default",
                "Teachers/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "iSIS.Website.Areas.Teachers.Controllers" }
            );
        }
    }
}