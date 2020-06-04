using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace SeleniumEasy.Utilities
{
    public class Driver
    {
        private static ConcurrentDictionary<long, IWebDriver> driverList = new ConcurrentDictionary<long, IWebDriver>();
        
        public static IWebDriver CurrentDriver => driverList[Thread.CurrentThread.ManagedThreadId];
        public static void InitializeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("incognito");
            driverList[Thread.CurrentThread.ManagedThreadId] = new ChromeDriver(options);
            CurrentDriver.Manage().Window.Maximize();
            CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}
