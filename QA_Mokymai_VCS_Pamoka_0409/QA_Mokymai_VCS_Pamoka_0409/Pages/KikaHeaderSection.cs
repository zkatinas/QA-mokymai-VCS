using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class KikaHeaderSection : BasePage
    {
        public KikaHeaderSection(IWebDriver driver) : base(driver)
        {
        }

        private By elementLoginIconButtonSelector = By.CssSelector("#profile_menu .need2login");
        private IWebElement elementLoginIconButton => driver.FindElement(elementLoginIconButtonSelector);
        IWebElement elementSearchIcon => driver.FindElement(By.Id("quick_search_show"));
        private string itemCountInCart => driver.FindElement(By.CssSelector("#cart_info em.cnt")).Text;
        private IWebElement elementCart => driver.FindElement(By.Id("cart_info"));

        private IWebElement elementProfileMenuButton => driver.FindElement(By.CssSelector("#profile_menu .ico.ico-profile"));
        private By elementLogOutSelector = By.CssSelector("#profile_menu a[href='?logout']");
        private IWebElement elementLogOut => driver.FindElement(elementLogOutSelector);


        public void ClickLoginIconButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLoginIconButtonSelector));
            elementLoginIconButton.Click();
        }

        public SearchPage ClickOnSearchIcon()
        {
            elementSearchIcon.Click();
            return new SearchPage(driver);
        }

        public void AssertCartIconNumber(string itemNumber)
        {
            Assert.AreEqual(itemNumber, itemCountInCart);
        }

        public void GoToCart()
        {
            elementCart.Click();
        }

        public void ProfileMenuDisplay()
        {
            elementProfileMenuButton.Click();
        }

        public void LogOut()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLogOutSelector));
            elementLogOut.Click();
        }
    }
}
