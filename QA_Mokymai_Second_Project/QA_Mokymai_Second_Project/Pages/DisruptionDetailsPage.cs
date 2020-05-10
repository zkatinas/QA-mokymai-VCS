using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_Second_Project_SkyCop.Utilities;
using System;

namespace QA_Mokymai_Second_Project_SkyCop.Pages
{
    public class DisruptionDetailsPage
    {
        IWebElement elementPageTitle => Driver.CurrentDriver.FindElement(By.Id("page-view-title"));

        public void VerifyPageTitle()
        {
            try
            {
                Driver.CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                WebDriverWait wait = new WebDriverWait(Driver.CurrentDriver, System.TimeSpan.FromSeconds(10));
                wait.Until(d => { return elementPageTitle.Text == "Type of disruption"; });
            }
            catch (WebDriverTimeoutException)
            {                
            }
            finally
            {
                Driver.CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }                        
            Assert.AreEqual("Type of disruption", elementPageTitle.Text);            
        }
    }
}
