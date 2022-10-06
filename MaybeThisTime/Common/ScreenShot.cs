using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using OpenQA.Selenium.Support.Extensions;
using WDSE;
using OpenQA.Selenium.Chrome;
using AngleSharp.Dom;

namespace MaybeThisTime.Common
{
    public class ScreenShot
    {

        public static void CaptureScreenshotByElement(IWebDriver driver, IWebElement element)
        {
            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("yyyy-mm-dd hh-mm-ss") + ".jpg";

            ITakesScreenshot ts = (ITakesScreenshot)driver;

            Byte[] byteArray = ts.GetScreenshot().AsByteArray;
            Bitmap screeenshot = new Bitmap(new System.IO.MemoryStream(byteArray));
            Rectangle croppedImage = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            screeenshot = screeenshot.Clone(croppedImage, screeenshot.PixelFormat);
            screeenshot.Save(String.Format(fileName, ImageFormat.Jpeg));

        }
        public static string ScreenshotFileName()
        {
            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("yyyy-MM-dd HH-mm-ss") + ".jpg";
            return fileName;
        }

        public static string ScreenshotPath()
        {
            string path = "G:\\screenshotWeb\\";
            return path;
        }

        public static void CaptureScreenshot2(IWebDriver driver)
        {
            DateTime time = DateTime.Now;
            string path = "G:\\screenshotWeb";
            string fileName = "Screenshot_" + time.ToString("yyyy-mm-dd hh-mm-ss") + ".jpg";
            string screenshotPathAndName = $@"{path}" + fileName;
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            ts.GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Png);

        }

        public static void CaptureScreenshot(IWebDriver driver)
        {
            DateTime time = DateTime.Now;
            string path = ScreenshotPath();
            string fileName = ScreenshotFileName();
            string screenshotNameAndPath = $"{path}{fileName}";
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            ts.GetScreenshot().SaveAsFile(screenshotNameAndPath, ScreenshotImageFormat.Png);

        }


    }
}
