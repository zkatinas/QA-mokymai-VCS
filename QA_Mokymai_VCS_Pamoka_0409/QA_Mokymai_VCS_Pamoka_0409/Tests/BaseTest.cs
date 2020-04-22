using NUnit.Framework;
using OpenQA.Selenium;
using QA_Mokymai_VCS_Pamoka_0409.Pages;
using QA_Mokymai_VCS_Pamoka_0409.Utils;

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
        public void BeforeTest()
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
            driver.Close();
            driver.Dispose();
        }

    }
}
