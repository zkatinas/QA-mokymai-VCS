using NUnit.Framework;
using OpenQA.Selenium;


namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class KikaHeaderSection : BasePage
    {
        public KikaHeaderSection(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement elementLoginIconButton => driver.FindElement(By.CssSelector(".need2login"));
        IWebElement elementSearchIcon => driver.FindElement(By.Id("quick_search_show"));
        private string itemCountInCart => driver.FindElement(By.CssSelector("#cart_info em.cnt")).Text;
        private IWebElement elementCart => driver.FindElement(By.Id("cart_info"));


        public void ClickLoginIconButton()
        {
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
    }
}
