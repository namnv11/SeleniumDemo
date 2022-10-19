using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstTest.WrapperFactory
{
    class ScreenShot
    {
        public static void SaveScreenShot(IWebDriver driver, string filename)
        {
            Console.WriteLine("---------\nSave Screencap");
            // Take ScreenCap of Entire Screen
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver != null)
            {
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                //Save as a jpg file
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            }
        }

        public static void SaveScreenShot(IWebDriver driver, string filename, IWebElement element)
        {
            // Take ScreenCap of Entire Screen
            var screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver != null)
            {
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                var bmpScreen = new Bitmap(new MemoryStream(screenshot.AsByteArray));
                // Crop ScreenCap to Element
                var cropArea = new Rectangle(element.Location, element.Size);
                Bitmap bmpCrop = bmpScreen.Clone(cropArea, bmpScreen.PixelFormat);
                //Save
                bmpCrop.Save(filename, ImageFormat.Jpeg);
            }
        }

        public static void SaveScreenShot(IWebDriver driver, string filename, string cssSelector)
        {
            // Take ScreenCap of Entire Screen
            var screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver != null)
            {
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                var bmpScreen = new Bitmap(new MemoryStream(screenshot.AsByteArray));
                //Get Element
                var element = driver.FindElement(By.CssSelector(cssSelector));
                // Crop ScreenCap to Element
                var cropArea = new Rectangle(element.Location, element.Size);
                Bitmap bmpCrop = bmpScreen.Clone(cropArea, bmpScreen.PixelFormat);
                //Save
                bmpCrop.Save(filename, ImageFormat.Jpeg);
            }
        }
    }
}
