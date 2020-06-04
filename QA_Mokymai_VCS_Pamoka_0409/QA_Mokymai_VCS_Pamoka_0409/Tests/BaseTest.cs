using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using QA_Mokymai_VCS_Pamoka_0409.API;
using QA_Mokymai_VCS_Pamoka_0409.Pages;
using QA_Mokymai_VCS_Pamoka_0409.Utils;



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
        protected ItemListing itemListing => PageFactory.ItemListing;


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

        protected void LoginWithtUser(User user)
        {
            //LoginWithtUser(user.Username, user.Password);
            var cookies = LoginAPI.Login(user);
            Driver.SetCookies(cookies);
            Driver.Current.Url = "https://www.kika.lt/";
            Driver.WriteAllCookies();
        }

        protected void LoginWithtUser(string username, string password)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                kikaHomePage.loginModal.Login(username, password);
            }, "Login with registered user");
        }
        
        protected void MakeScreenshotOnTestFailure()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
                {
                    AllureLifecycle.Instance.WrapInStep(() =>
                    { 
                        var screenshots = ScreenshotMaker.TakeScreenshot();
                        AllureLifecycle.Instance.AddAttachment("Failed Screenshot", "image/png", screenshots, "png");
                   
                    }, "Failed test screenshot");
                }
            }
            catch (WebDriverException)
            {
            }
        }       
    }
}
