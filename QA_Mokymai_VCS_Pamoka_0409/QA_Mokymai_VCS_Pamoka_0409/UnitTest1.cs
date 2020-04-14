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
        //private ChromeDriver driver; - siauriau uz IWebDriver, nes tai tik chrome driveris
        private IWebDriver driver;

        private By elementPopupCloseButtonSelector = By.CssSelector("#editable_popup[style*='display: block;'] .close");
        private By elementAddToCartButtonSelector = By.Id("add2cart_button");

        //"=>" tas pats, kas "get"
        private IWebElement elementPopupCloseButton => driver.FindElement(elementPopupCloseButtonSelector);
        private IWebElement elementPopupCloseButtonAfterLogin => driver.FindElement(elementPopupCloseButtonSelector);
        private IWebElement elementAddToCartButton => driver.FindElement(elementAddToCartButtonSelector);

        private const string LoginFormId = "login_form";

        private IWebElement elementLoginIconButton => driver.FindElement(By.CssSelector(".need2login"));
        private IWebElement elementEmailInput => driver.FindElement(By.CssSelector($"#{LoginFormId} [name='email']"));
        private IWebElement elementPasswordInput => driver.FindElement(By.CssSelector($"#{LoginFormId} [name='password']"));
        private IWebElement elementLoginButton => driver.FindElement(By.CssSelector($"#{LoginFormId} .btn-primary"));

        private IList<IWebElement> visibleItems => driver.FindElements(By.CssSelector(".owl-item.active"));
        private IList<IWebElement> selcetQuantity => driver.FindElements(By.CssSelector(".qty-select .plus"));

        private string itemCountInCartBeforeBuy => driver.FindElement(By.CssSelector("em.cnt")).Text;
        private string zeroItemInCart = "0";
        private string itemCountInCartAfterBuy => driver.FindElement(By.CssSelector("em.cnt")).Text;
        private string oneItemInCart = "1";




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
            //IWebElement elementPopupCloseButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#editable_popup[style*='display: block;'] .close")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementPopupCloseButtonSelector));            
            elementPopupCloseButton.Click();

            Thread.Sleep(2000);
            //Randame "login" mygtuka pagal klase "need2login"
            //IWebElement elementLoginIconButton = driver.FindElement(By.CssSelector(".need2login"));
            elementLoginIconButton.Click();

            Thread.Sleep(1500);
            //Randame "email" laukeli pagal formos "id" ir pagal laukelio "name"
            //IWebElement elementEmailInput = driver.FindElement(By.CssSelector($"#{LoginFormId} [name='email']"));
            elementEmailInput.SendKeys("testeris888@test.lt");

            //Randame "password" laukeli pagal formos "id" ir pagal laukelio "name"
            //IWebElement elementPasswordInput = driver.FindElement(By.CssSelector($"#{LoginFormId} [name='password']"));
            elementPasswordInput.SendKeys("testeris888");

            //Randame "Prisijungti" mygtuka pagal formos "id" ir pagal mygtuko klase "btn-primary"
            //IWebElement elementLoginButton = driver.FindElement(By.CssSelector("#login_form .btn-primary"));
            elementLoginButton.Click();

            Thread.Sleep(1000);
            //IWebElement elementPopupCloseButtonAfterLogin = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#editable_popup[style*='display: block;'] .close")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementPopupCloseButtonSelector));
            elementPopupCloseButtonAfterLogin.Click();

            Thread.Sleep(1000);
            //IWebElement elementUserIconAfterLogin = driver.FindElement(By.CssSelector("#profile_menu .ico-profile"));
            //elementUserIconAfterLogin.Click();
            //
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
            //string itemCountInCartBeforeBuy = driver.FindElement(By.CssSelector("em.cnt")).Text;
            //string zeroItemInCart = "0";
            Assert.AreEqual(itemCountInCartBeforeBuy, zeroItemInCart);

            //Parenkame pirma rodoma item
            //IList<IWebElement> visibleItems = driver.FindElements(By.CssSelector(".owl-item.active"));
            visibleItems[0].Click();

            //Parenkame item kieki
            //IList<IWebElement> selcetQuantity = driver.FindElements(By.CssSelector(".qty-select .plus"));
            selcetQuantity[0].Click();
            //IWebElement elementAddToCartButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("add2cart_button")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementAddToCartButtonSelector));            
            elementAddToCartButton.Click();

            //Patikriname, ar item idetas i krepseli
            Thread.Sleep(3500);
            //string itemCountInCartAfterBuy = driver.FindElement(By.CssSelector("em.cnt")).Text;
            //string oneItemInCart = "1";
            Assert.AreEqual(itemCountInCartAfterBuy, oneItemInCart);
            
            Thread.Sleep(3000);
        }


        [TearDown]
        public void Close_Browser()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
