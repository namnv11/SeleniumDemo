using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstTest.WrapperFactory
{
    public class BrowserFactory
    {
        private static FirefoxOptions _firefoxOptions;
        private static ChromeOptions _chromeOptions;
        private static InternetExplorerOptions _internetExplorerOptions;

        public static IWebDriver Driver { get; private set; }

        private static FirefoxOptions FirefoxOptions
        {
            get
            {
                if (_firefoxOptions == null)
                {
                    _firefoxOptions = new FirefoxOptions();
                    //firefoxOptions.AddArguments("--headless");
                    _firefoxOptions.AcceptInsecureCertificates = true;
                    //firefoxOptions.AddArgument("no-sandbox");

                }
                return _firefoxOptions;
            }
        }

        private static ChromeOptions ChromeOptions
        {
            get
            {
                if (_chromeOptions == null)
                {
                    _chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArguments("--start-maximized");
                    _chromeOptions.AcceptInsecureCertificates = true;
                    //chromeOptions.AddArgument("no-sandbox");

                }
                return _chromeOptions;
            }
        }

        private static InternetExplorerOptions InternetExplorerOptions
        {
            get
            {
                if (_internetExplorerOptions == null)
                {
                    _internetExplorerOptions = new InternetExplorerOptions();
                    _internetExplorerOptions.IgnoreZoomLevel = true;
                }
                return _internetExplorerOptions;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    Driver = new FirefoxDriver(FirefoxOptions);
                    break;
                case "Chrome":
                    Driver = new ChromeDriver(ChromeOptions);
                    break;
                case "IE":
                    Driver = new InternetExplorerDriver(InternetExplorerOptions);
                    break;
            }

        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            Driver.Close();
            Driver.Quit();
            Driver = null;
        }

        public static void Wait(int miliseconds, int maxTimeOutSeconds = 60)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 1, maxTimeOutSeconds));
            var delay = new TimeSpan(0, 0, 0, 0, miliseconds);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);
        }

        public static int WindowsCount()
        {
            return Driver.WindowHandles.Count;
        }

        public static string CurrentURL()
        {
            return Driver.Url;
        }
    }
}
