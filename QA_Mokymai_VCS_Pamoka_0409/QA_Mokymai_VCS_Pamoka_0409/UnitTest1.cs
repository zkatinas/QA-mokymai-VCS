using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_VCS_Pamoka_0409.Pages;
using System;
using System.Collections.Generic;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409
{
    
   
    public class Tests
    {
        //private ChromeDriver driver; - siauriau uz IWebDriver, nes tai tik chrome driveris
        private IWebDriver driver;
        private KikaHomePage kikaHomePage;
        private LoginModal loginModal;
        private PopUpModal popUpModal;
        private Item item;
        private Cart cart;   
        

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
            kikaHomePage = new KikaHomePage(driver);
            loginModal = new LoginModal(driver);
            popUpModal = new PopUpModal(driver);
            item = new Item(driver);
            cart = new Cart(driver);

        }
        [Test]
        public void TestLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            Thread.Sleep(2000);
            //Suranda pop lango "close" mygtuka ir ji paspaudzia
            //driver.FindElement(By.CssSelector("#editable_popup[style='display: block;'] .close")).Click();
            //IWebElement elementPopupCloseButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#editable_popup[style*='display: block;'] .close")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementPopupCloseButtonSelector));            
            //elementPopupCloseButton.Click();
            popUpModal.ClosePopUpModal();

            Thread.Sleep(2000);
            //Randame "login" mygtuka pagal klase "need2login"
            //IWebElement elementLoginIconButton = driver.FindElement(By.CssSelector(".need2login"));            
            kikaHomePage.ClickLoginIconButton();

            Thread.Sleep(1500);
            //Randame "email" laukeli pagal formos "id" ir pagal laukelio "name"
            //IWebElement elementEmailInput = driver.FindElement(By.CssSelector($"#{LoginFormId} [name='email']"));            
            loginModal.EnterEmail("testeris888@test.lt");

            //Randame "password" laukeli pagal formos "id" ir pagal laukelio "name"
            //IWebElement elementPasswordInput = driver.FindElement(By.CssSelector($"#{LoginFormId} [name='password']"));            
            loginModal.EnterPassword("testeris888");  

            //Randame "Prisijungti" mygtuka pagal formos "id" ir pagal mygtuko klase "btn-primary"
            //IWebElement elementLoginButton = driver.FindElement(By.CssSelector("#login_form .btn-primary"));            
            loginModal.ClickLoginFormButton();

            // Galima naudoti bendra metoda
            //loginModal.Login("testeris888@test.lt", "testeris888");

            //Galima naudoti "chain"
            //loginModal.EnterEmail("testeris888@test.lt").EnterEmail("testeris888").ClickLoginFormButton();

            Thread.Sleep(1000);
            //IWebElement elementPopupCloseButtonAfterLogin = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#editable_popup[style*='display: block;'] .close")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementPopupCloseButtonSelector));
            //elementPopupCloseButtonAfterLogin.Click();
            popUpModal.ClosePopUpModal();

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
            //WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
                      
            TestLogin();

            //Patikriname, ar krepselyje nera prekiu
            //string itemCountInCartBeforeBuy = driver.FindElement(By.CssSelector("em.cnt")).Text;
            //string zeroItemInCart = "0";
            //Assert.AreEqual(itemCountInCartBeforeBuy, zeroItemInCart);
            kikaHomePage.AssertCartIconNumber("0");

            //Parenkame pirma rodoma item
            //IList<IWebElement> visibleItems = driver.FindElements(By.CssSelector(".owl-item.active"));            
            kikaHomePage.ClickFirstItem();



            //TO DO ?????????????????????

            //string itemName = driver.FindElement(By.CssSelector(".summary_wrp h1")).Text;
            //item.GetItemName();
            //IList<IWebElement> itemPriceList = driver.FindElements(By.CssSelector(".prices .price"));
            //string itemPrice = itemPriceList[0].Text;
            



            //Parenkame item kieki
            //IList<IWebElement> selcetQuantity = driver.FindElements(By.CssSelector(".qty-select .plus"));
            //selectQuantity[0].Click();
            item.SelectItemQuantity();

            //IWebElement elementAddToCartButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("add2cart_button")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementAddToCartButtonSelector));            
            //elementAddToCartButton.Click();
            item.AddToCart();

            //Patikriname, ar item idetas i krepseli
            Thread.Sleep(3500);
            //string itemCountInCartAfterBuy = driver.FindElement(By.CssSelector("em.cnt")).Text;
            //string oneItemInCart = "1";
            //Assert.AreEqual(itemCountInCartAfterBuy, oneItemInCart);
            kikaHomePage.AssertCartIconNumber("1");

            //IWebElement elementCart = driver.FindElement(By.Id("cart_info"));
            //elementCart.Click();
            cart.GoToCart();



            // ???????????????????
            //TO DO: assert item name/price with item in cart name/price - variables from 2

            //string itemInCartName = driver.FindElement(By.CssSelector("#cart_items .product_name")).Text;
            //string itemInCartPriceWithTitle = driver.FindElement(By.CssSelector("#cart_items .price")).Text;
            //string[] list = itemInCartPriceWithTitle.Split("\n");            
            //string itemInCartPrice = list[1];           
            //Assert.AreEqual(itemName, itemInCartName);
            //Assert.AreEqual(itemPrice, itemInCartPrice);


            cart.RemoveItemFromCart();
            Thread.Sleep(2000);
            cart.ProfileMenuDisplay();
            cart.LogOut();

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
