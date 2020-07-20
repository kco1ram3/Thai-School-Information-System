using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iSISDemo.Classes
{
    public class SessionManager
    {
        public enum SessionName
        {
            CurrentUser,
            CurrentSchool,
            CurrentRole,
            CurrentAuthorizeModule,
            CurrentAuthorizeScreen,
            CurrentModule
        }

        #region SetSession
        public static void SetSession(Controller page, SessionName name, object value)
        {
            page.Session[name.ToString()] = value;
        }
        #endregion

        #region GetSession
        public static object GetSession(Controller page, SessionName name)
        {
            return page.Session[name.ToString()];
        }

        public static object GetSession(HttpContextBase page, SessionName name)
        {
            return page.Session[name.ToString()];
        }

        public static object GetSession(HttpContext page, SessionName name)
        {
            return page.Session[name.ToString()];
        }
        #endregion

        #region RemoveSession
        public static void RemoveSession(Controller page)
        {
            string[] names = Enum.GetNames(typeof(SessionName));
            foreach (string n in names)
            {
                page.Session.Remove(n);
            }
        }

        public static void RemoveSession(Controller page, SessionName name)
        {
            page.Session.Remove(name.ToString());
        }
        #endregion
    }
}