using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    public class Driver
    {
        private static IWebDriver driver;
        public static IWebDriver Current => driver;      
        
        public static void Init()
        {
            switch (EnvironmentManager.browser)
            {
                case Browser.Chrome:
                    //ChromeOptions leidzia nurodyti chrome narsykles options: incognito, isdidinatas langas
                    var options = new ChromeOptions();
                    options.AddArguments("incognito");
                    driver = new ChromeDriver(options);
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    Assert.Fail("Driver not supported!");
                    break;
            }                
            
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);            
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
        Firefox
    }
}
