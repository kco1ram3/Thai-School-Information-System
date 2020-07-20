using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSIS.Classes
{
    public class CookieManager
    {
        private readonly static string COOKIE_NAME = "TSIS";
        public enum CookieName
        {
            CurrentTheme,
            CurrentLanguage
        }

        #region SetCookie
        public static void SetCookie(Controller page, CookieName name, string value)
        {
            HttpCookie cookie = page.HttpContext.Request.Cookies[COOKIE_NAME];
            if (cookie == null)
            {
                cookie = new HttpCookie(COOKIE_NAME);
            }
            cookie.Values[name.ToString()] = value;
            page.HttpContext.Response.SetCookie(cookie);
        }

        public static void SetCookie(HttpContextBase page, CookieName name, string value)
        {
            HttpCookie cookie = page.Request.Cookies[COOKIE_NAME];
            if (cookie == null)
            {
                cookie = new HttpCookie(COOKIE_NAME);
            }
            cookie.Values[name.ToString()] = value;
            page.Response.SetCookie(cookie);
        }
        #endregion

        #region GetCookie
        public static string GetCookie(Controller page, CookieName name)
        {
            HttpCookie cookie = page.HttpContext.Request.Cookies[COOKIE_NAME];
            if (cookie == null)
            {
                cookie = new HttpCookie(COOKIE_NAME);
            }
            return cookie.Values[name.ToString()];
        }

        public static string GetCookie(HttpContextBase page, CookieName name)
        {
            HttpCookie cookie = page.Request.Cookies[COOKIE_NAME];
            if (cookie == null)
            {
                cookie = new HttpCookie(COOKIE_NAME);
            }
            return cookie.Values[name.ToString()];
        }

        public static string GetCookie(HttpContext page, CookieName name)
        {
            HttpCookie cookie = page.Request.Cookies[COOKIE_NAME];
            if (cookie == null)
            {
                cookie = new HttpCookie(COOKIE_NAME);
            }
            return cookie.Values[name.ToString()];
        }
        #endregion
    }
}