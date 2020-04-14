using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409
{
    
   
    public class Tests
    {
        //private ChromeDriver driver;
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //ChromeOptions leidzia nurodyti chrome narsykles options: incognito, isdidinatas langas
            var options = new ChromeOptions();
            options.AddArguments("incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.kika.lt/";
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
        }
        [Test]
        public void TestLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            Thread.Sleep(2000);
            //Suranda pop lango "close" mygtuka ir ji paspaudzia
            //driver.FindElement(By.CssSelector("#editable_popup[style='display: block;'] .close")).Click();
            IWebElement elementClosePopup = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#editable_popup[style*='display: block;'] .close")));
            elementClosePopup.Click();

            Thread.Sleep(2000);
            //Randame "login" mygtuka pagal klase "need2login"
            driver.FindElement(By.CssSelector(".need2login")).Click();

            Thread.Sleep(1000);
            //Randame "email" laukeli pagal formos "id" ir pagal laukelio "name"
            driver.FindElement(By.CssSelector("#login_form [name='email']")).SendKeys("testeris888@test.lt");

            //Randame "password" laukeli pagal formos "id" ir pagal laukelio "name"
            driver.FindElement(By.CssSelector("#login_form [name='password']")).SendKeys("testeris888");

            //Randame "Prisijungti" mygtuka pagal formos "id" ir pagal mygtuko klase "btn-primary"
            driver.FindElement(By.CssSelector("#login_form .btn-primary")).Click();

            Thread.Sleep(1000);
            IWebElement elementClosePopupAfterLogin = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#editable_popup[style*='display: block;'] .close")));
            elementClosePopupAfterLogin.Click();

            Thread.Sleep(1000);
            //driver.FindElement(By.CssSelector("#profile_menu .ico-profile")).Click();
            //Thread.Sleep(1000);

            //Patikrinti, ar prisijunges
            //string userLogged = driver.FindElement(By.CssSelector("#profile_menu.dropdown .dropdown-menu[style*='display: block;'] a[href='https://www.kika.lt/paskyra/uzsakymai/']")).Text;
            //string manoUzsakymai = "Mano užsakymai";
            //Assert.AreEqual(userLogged, manoUzsakymai);
            //Thread.Sleep(2000);
        }

        [Test]
        public void AddFirstFoodInList()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
                      
            TestLogin();

            //Patikriname, ar krepselyje nera prekiu
            string itemCountInCartBeforeBuy = driver.FindElement(By.CssSelector("em.cnt")).Text;
            string zeroItemInCart = "0";
            Assert.AreEqual(itemCountInCartBeforeBuy, zeroItemInCart);

            //Parenkame pirma rodoma item
            IList<IWebElement> visibleItems = driver.FindElements(By.CssSelector(".owl-item.active"));
            visibleItems[0].Click();

            //Parenkame item kieki
            IList<IWebElement> selcetQuantity = driver.FindElements(By.CssSelector(".qty-select .plus"));
            selcetQuantity[0].Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("add2cart_button"))).Click();

            //Patikriname, ar item idetas i krepseli
            System.Threading.Thread.Sleep(3000);
            string itemCountInCartAfterBuy = driver.FindElement(By.CssSelector("em.cnt")).Text;
            string oneItemInCart = "1";
            Assert.AreEqual(itemCountInCartAfterBuy, oneItemInCart);
            
            System.Threading.Thread.Sleep(3000);
        }


        [TearDown]
        public void Close_Browser()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
