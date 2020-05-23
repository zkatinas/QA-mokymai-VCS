using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class KikaHeaderSection
    {
        private IWebDriver driver => Driver.Current;

        private By elementLoginIconButtonSelector = By.CssSelector("#profile_menu .need2login");
        private IWebElement elementLoginIconButton => driver.FindElement(elementLoginIconButtonSelector);
        private IWebElement elementSearchIcon => driver.FindElement(By.Id("quick_search_show"));
        private IWebElement itemCountInCart => driver.FindElement(By.CssSelector("#cart_info em.cnt"));
        private IWebElement elementCart => driver.FindElement(By.Id("cart_info"));

        private By elementProfileMenuButtonSelector = By.CssSelector("#profile_menu .ico-profile");
        private IWebElement elementProfileMenuButton => driver.FindElement(elementProfileMenuButtonSelector);
        private By elementWishlistCountSelector = By.CssSelector("#wishlist_info .cnt");
        private IWebElement elementWishlistCount => driver.FindElement(elementWishlistCountSelector);
        private By elementLogOutSelector = By.CssSelector("#profile_menu a[href='?logout']");
        private IWebElement elementLogOut => driver.FindElement(elementLogOutSelector);


        public void ClickLoginIconButton()
        {
            Waits.WaitUntilModalBackgroundIsNotVisible();
            elementLoginIconButton.Click();

            // Try catch ?? Nes interceptina click'a.
            //for (int i = 0; i < 4; i++)
            //{
            //    try
            //    {
            //        elementLoginIconButton.Click();
            //        break;
            //    }
            //    catch (ElementClickInterceptedException)
            //    {
            //        continue;
            //    }

            //}           
        }

        public SearchPage ClickOnSearchIcon()
        {
            elementSearchIcon.Click();
            return PageFactory.SearchPage;
        }

        public void AssertCartIconNumber(string itemNumber)
        {
            Assert.AreEqual(itemNumber, itemCountInCart.Text);
        }

        public void ClickOnCartIcon()
        {
            elementCart.Click();
        }

        public void ClickOnProfileMenuIcon()
        {
            //Driver.TurnOffImplicitWait();
            //WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementProfileMenuButtonSelector));
            elementProfileMenuButton.Click();
            //Driver.TurnOnImplicitWait();
        }

        public void CheckIfUserIsLogged()
        {
            Driver.TurnOffImplicitWait();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementWishlistCountSelector));
            //Assert.AreEqual(loggedUserProfileElement, elementWishlistCount);
            Assert.IsTrue(elementWishlistCount.Text != null, "Wishlist is not visible");
            Console.WriteLine(elementWishlistCount.Text);
            Driver.TurnOnImplicitWait();
        }

        public void LogOut()
        {
            Driver.TurnOffImplicitWait();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLogOutSelector));
            elementLogOut.Click();
            Driver.TurnOnImplicitWait();
        }
    }
}
