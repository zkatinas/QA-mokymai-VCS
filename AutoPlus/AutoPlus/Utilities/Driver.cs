using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPlus.Utilities
{
    public class Driver
    {
        public static IWebDriver CurrentDriver;

        public static void InitializeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("incognito");
            CurrentDriver = new ChromeDriver(options);
            CurrentDriver.Manage().Window.Maximize();
            CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30); 
        }
    }
}
