using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    public class Driver
    {
        // ConcurrentDictionary - reikalingas paraleliniam testu paleidimui; saugus "multithread"
        private static ConcurrentDictionary<int,IWebDriver> driverList = new ConcurrentDictionary<int,IWebDriver>();

        //Thread.CurrentThread.ManagedThreadId = gauname dabartini thread
        public static IWebDriver Current => driverList[Thread.CurrentThread.ManagedThreadId];      
        
        public static void Init()
        {
            IWebDriver driver = null;
            switch (EnvironmentManager.browser)
            {
                case Browser.Chrome:
                    //ChromeOptions leidzia nurodyti chrome narsykles options: incognito, isdidinatas langas
                    var options = new ChromeOptions();
                    options.AddArguments("incognito");
                    driver = new ChromeDriver(options);
                    break;
                case Browser.ChromeRemote:
                    var options2 = new ChromeOptions();
                    options2.AddArgument("incognito");
                    options2.PlatformName = "Windows 10";
                   /* options2.BrowserVersion = "81"*/;
                    driver = new RemoteWebDriver(new Uri("http://192.168.1.177:4444/wd/hub"), options2.ToCapabilities());
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    Assert.Fail("Driver not supported!");
                    break;
            }
            driverList[Thread.CurrentThread.ManagedThreadId] = driver;
            Current.Manage().Window.Maximize();
            Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
        }

        public static void Quit()
        {
            Current.Quit();
        }        

        public static void TurnOnImplicitWait()
        {
            Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public static void TurnOffImplicitWait()
        {
            Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public static void ChangeImplicitWait(int seconds)
        {
            Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void RefreshPage()
        {
            Current.Navigate().Refresh();
        }
    }
    public enum Browser
    {
        Chrome,
        Firefox,
        ChromeRemote
    }
}
