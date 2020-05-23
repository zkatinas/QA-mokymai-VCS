using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    public class ScreenshotMaker
    {
        public static byte[] TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver.Current).GetScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}_{DateAndTime.Now.ToString("yy-MM-dd_HH_mm_ss")}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            // Add that file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            return screenshot.AsByteArray;
        }

    }
}
