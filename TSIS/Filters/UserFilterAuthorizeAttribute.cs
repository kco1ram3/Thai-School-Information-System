using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TSIS.Models;
using TSIS.Classes;

namespace TSIS.Filters
{
    public class UserFilterAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //filterContext.Controller.ViewBag.AutherizationMessage = "Custom Authorization: Message from OnAuthorization method.";
            if (CookieManager.GetCookie(filterContext.HttpContext, CookieManager.CookieName.CurrentTheme) == null)
            {
                CookieManager.SetCookie(filterContext.HttpContext, CookieManager.CookieName.CurrentTheme, Themes.GetThemes()[0].Value);
            }
            if (CookieManager.GetCookie(filterContext.HttpContext, CookieManager.CookieName.CurrentLanguage) == null)
            {
                IList<iSISModel.Language> language = (IList<iSISModel.Language>)CacheManager.GetCache(CacheManager.CacheName.Language);
                if (language.Count > 0)
                {
                    CookieManager.SetCookie(filterContext.HttpContext, CookieManager.CookieName.CurrentLanguage, language[0].Code);
                }
            }

            if (SessionManager.GetSession(filterContext.HttpContext, SessionManager.SessionName.CurrentUser) == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "", controller = "User", action = "Login" }));
            }
        }  
    }
}