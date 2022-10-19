using MyFirstTest.Config;
using MyFirstTest.WrapperFactory;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;

namespace MyFirstTest.TestCases.BaseClass
{
    public class BaseClass
    {
        [SetUp]
        protected void SetUpBeforeTestMethod()
        {
            BrowserFactory.InitBrowser(ConfigHelper.Browser);
            BrowserFactory.LoadApplication(ConfigHelper.Url);
        }

        [TearDown]
        protected void TearDownAfterTestMethod()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string fileName = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory)) + "\\ScreenShots\\" + TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".jpeg";
                ScreenShot.SaveScreenShot(BrowserFactory.Driver, fileName);
                TestContext.AddTestAttachment(fileName);
            }
            BrowserFactory.CloseAllDrivers();
        }
    }
}
