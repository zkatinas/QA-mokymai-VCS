using Microsoft.VisualBasic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using QA_Mokymai_VCS_Pamoka_0409.Pages;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System;
using System.IO;


namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    public abstract class BaseTest
    {
        //private ChromeDriver driver; - siauriau uz IWebDriver, nes tai tik chrome driveris        
        protected KikaHomePage kikaHomePage => PageFactory.KikaHomePage;
        protected LoginModal loginModal => PageFactory.LoginModal;
        protected PopUpModal popUpModal => PageFactory.PopUpModal;
        protected Item item => PageFactory.Item;
        protected Cart cart => PageFactory.Cart;
        protected PageMenuSection pageMenuSection => PageFactory.PageMenuSection;


        [SetUp]
        public void BaseBeforeTest()
        {            
            Driver.Init();            
            Driver.Current.Url = "https://www.kika.lt/";
              
        }
              

        [TearDown]
        public void QuitDriver()
        {
            //Kvieciame metoda del screenshot'u TearDown'e
            MakeScreenshotOnTestFailure();
            Driver.Quit();
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
                ScreenshotMaker.TakeScreenshot();
            }
        }       

    }
}
