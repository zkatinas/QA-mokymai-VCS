using Microsoft.VisualBasic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_VCS_Pamoka_0409.Pages;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System;
using System.IO;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    public abstract class BaseTest
    {
        //private ChromeDriver driver; - siauriau uz IWebDriver, nes tai tik chrome driveris
        protected IWebDriver driver;
        protected KikaHomePage kikaHomePage;
        protected LoginModal loginModal;
        protected PopUpModal popUpModal;
        protected Item item;
        protected Cart cart;
       

        [SetUp]
        public void BaseBeforeTest()
        {            
            driver = Driver.Init();
            InitPages();
            driver.Url = "https://www.kika.lt/";
              
        }

        private void InitPages()
        {
            kikaHomePage = new KikaHomePage(driver);
            loginModal = new LoginModal(driver);
            popUpModal = new PopUpModal(driver);
            item = new Item(driver);
            cart = new Cart(driver);
        }

        [TearDown]
        public void QuitDriver()
        {
            //Kvieciame metoda del screenshot'u TearDown'e
            MakeScreenshotOnTestFailure();
            driver.Close();
            driver.Dispose();
        }


        //Neveikia???
        protected void LoginWithDefaultUser()
        {
            kikaHomePage.Login(User.DefaultKikaUser);
        }

        //protected void LoginWithtUser(User user)
        //{
        //    LoginWithtUser(user.Username, user.Password);
        //}

        protected void LoginWithtUser(string username, string password)
        {
            kikaHomePage.loginModal.Login(username, password);
        }


        protected void MakeScreenshotOnTestFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                DoScreenshot();
            }
        }

        protected void DoScreenshot()
        {
            Screenshot screenshot = driver.TakeScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}_{DateAndTime.Now.ToString("yy-MM-dd HH:mm:ss")}.jpg");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Jpeg);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            // Add that file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            //return screenshot.AsByteArray;
        }

    }
}
