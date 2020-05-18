using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace QA_Mokymai_Second_Project_SkyCop.Utilities
{
    public class Driver
    {
        private static ConcurrentDictionary<int, IWebDriver> driverList = new ConcurrentDictionary<int, IWebDriver>();
        public static IWebDriver CurrentDriver => driverList[Thread.CurrentThread.ManagedThreadId];               

        public static object Current { get; internal set; }

        public static void InitiliazeDriver()
        {
            Uri remoteServer = new Uri("http://192.168.1.177:4444/wd/hub");
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("incognito");
            //driverList[Thread.CurrentThread.ManagedThreadId] = new ChromeDriver(chromeOptions);            
            driverList[Thread.CurrentThread.ManagedThreadId] = new RemoteWebDriver(remoteServer, chromeOptions.ToCapabilities());            
            CurrentDriver.Manage().Window.Maximize();
            CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
