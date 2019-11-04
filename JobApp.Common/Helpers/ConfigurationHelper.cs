using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Common.Helpers
{
    public static class ConfigurationHelper
    {
        private readonly static NameValueCollection Values = new NameValueCollection();
        public static string GetConfiguration(string key, string defaultValue = "")
        {
            if (Values.AllKeys.Contains(key))
            {
                return Values[key];
            }
            else
            {
                if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                {
                    return ConfigurationManager.AppSettings.Get(key);
                }
            }

            return defaultValue;
        }

        public static void SetConfiguration(string key, string value)
        {
            Values.Set(key, value);
        }
    }
}
