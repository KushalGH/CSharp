using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace CSharp.MVC
{
    public class CustomCacheInMVC
    {

        static readonly ObjectCache Cache = MemoryCache.Default;

        /// <summary>
        /// Adding Item to the Cache
        /// </summary>
        /// <param name="objectToCache"></param>
        /// <param name="key"></param>
        public static void AddItem(object objectToCache, string key)
        {
            int application_cache_days = Convert.ToInt32(Resources.GetConfig(ConfigConstants.Application_Cache_Days));
            Cache.Add(key, objectToCache, DateTime.Now.AddDays(application_cache_days > 0 ? application_cache_days : Constants.Application_Cache_Days_Default));
        }

        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)Cache[key];
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
}