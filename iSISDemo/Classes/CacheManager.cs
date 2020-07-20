using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iSISDemo.Classes
{
    public class CacheManager
    {
        public enum CacheName 
        {
            Language,
            ClassLevel,
            GradingSystem,
            Course,
            Country,
            GeographicRegion,
            Label,
            AddressCategory,
            Room,
            CurriculumFramework
        }

        #region SetCache
        public static void SetCache(CacheName name, object value)
        {
            HttpRuntime.Cache[name.ToString()] = value;
        }
        #endregion

        #region GetCache
        public static object GetCache(CacheName name)
        {
            return HttpRuntime.Cache[name.ToString()];
        }
        #endregion

        #region RemoveCache
        public static void RemoveCache()
        {
            string[] names = Enum.GetNames(typeof(CacheName));
            foreach (string n in names)
            {
                if (GetCache((CacheName)Enum.Parse(typeof(CacheName), n)) != null)
                {
                    HttpRuntime.Cache.Remove(n.ToString());
                }
            }
        }

        public static void RemoveCache(CacheName name)
        {
            if (GetCache(name) != null)
            {
                HttpRuntime.Cache.Remove(name.ToString());
            }
        }
        #endregion
    }
}