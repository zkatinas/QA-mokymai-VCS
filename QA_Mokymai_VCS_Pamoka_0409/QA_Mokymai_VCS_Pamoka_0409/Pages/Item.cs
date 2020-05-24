using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using NUnit.Allure.Core;
using Allure.Commons;
using QA_Mokymai_VCS_Pamoka_0409.Utils;

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
            var itemName = "";
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                itemName = itemNameInItemPage.Text;
            }, "Get selected item name");
            return itemName;
        }

        public string GetItemPrice()
        {
            var itemPrice = "";
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                itemPrice = itemPriceInItemPage.Text;
            }, "Get selected item price");
            return itemPrice;
        }

        public void SelectItemQuantity()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                selectItemQuantity[0].Click();
            }, "Select item quantity from the list");
        }

        public void AddToCart()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Driver.TurnOffImplicitWait();
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementAddToCartButtonSelector));
                elementAddToCartButton.Click();
                Driver.TurnOnImplicitWait();
            }, "Add item to cart");
        }       
    }
}
