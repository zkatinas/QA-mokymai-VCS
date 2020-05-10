using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_Second_Project_SkyCop.Utilities
{
    public class Driver
    {
        public static IWebDriver CurrentDriver;

        public static object Current { get; internal set; }

        public static void InitiliazeDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("incognito");
            CurrentDriver = new ChromeDriver(chromeOptions);
            CurrentDriver.Manage().Window.Maximize();
            CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }




    }
}
