using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstTest.Config
{
    public class ConfigHelper
    {
        public static string Browser => GetVariable("BrowserToUse");

        public static string Url => GetVariable("URL");

        private static string GetVariable(string name)
        {
            var environmentValue = Environment.GetEnvironmentVariable(name);
            if (environmentValue != null)
            {
                return environmentValue;
            }
            return ConfigurationManager.AppSettings[name];
        }
    }
}
