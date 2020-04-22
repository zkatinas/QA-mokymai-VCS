using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    public class Driver
    {
               
        
        public static IWebDriver Init()
        {
            //ChromeOptions leidzia nurodyti chrome narsykles options: incognito, isdidinatas langas
            var options = new ChromeOptions();
            options.AddArguments("incognito");
            var driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }


    }
}
