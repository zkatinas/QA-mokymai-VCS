using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class Item : BasePage
    {
        
        //TO DO ??????????????????
        //Not used in assertion
        private IWebElement itemNameInItemPage => driver.FindElement(By.CssSelector(".summary_wrp h1"));
        private IList<IWebElement> itemPriceList => driver.FindElements(By.CssSelector(".prices .price"));
        private IWebElement itemPriceInItemPage => itemPriceList[0];
        
        private By elementAddToCartButtonSelector = By.Id("add2cart_button");        
        private IWebElement elementAddToCartButton => driver.FindElement(elementAddToCartButtonSelector);
        private IList<IWebElement> selectItemQuantity => driver.FindElements(By.CssSelector(".qty-select .plus"));
        
        public string GetItemName()
        {
            return itemNameInItemPage.Text;
        }

        public string GetItemPrice()
        {
            return itemPriceInItemPage.Text;
        }

        public void SelectItemQuantity()
        {
            selectItemQuantity[0].Click();
        }

        public void AddToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementAddToCartButtonSelector));
            elementAddToCartButton.Click();
        }       
    }
}
