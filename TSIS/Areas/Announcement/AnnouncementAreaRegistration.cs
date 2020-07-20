using System.Web.Mvc;

namespace TSIS.Areas.Announcement
{
    public class AnnouncementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Announcement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Announcement_default",
                "Announcement/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TSIS.Areas.Announcement.Controllers" }
            );
        }
    }
}