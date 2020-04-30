﻿using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    public class ScreenshotMaker
    {
        public static void TakeScreenshot()
        {
            Screenshot screenshot = Driver.Current.TakeScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}_{DateAndTime.Now.ToString("yy-MM-dd HH:mm:ss")}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            // Add that file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            //return screenshot.AsByteArray;
        }

    }
}
