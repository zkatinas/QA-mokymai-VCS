using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    class Item
    {
        private IWebDriver driver;

        public Item(IWebDriver driver)
        {
            this.driver = driver;
        }



        //TO DO ??????????????????
        //Not used in assertion
        private string itemName => driver.FindElement(By.CssSelector(".summary_wrp h1")).Text;
        private IList<IWebElement> itemPriceList => driver.FindElements(By.CssSelector(".prices .price"));
        private string itemPrice => itemPriceList[0].Text;

        private By elementAddToCartButtonSelector = By.Id("add2cart_button");
        private IWebElement elementAddToCartButton => driver.FindElement(elementAddToCartButtonSelector);
        private IList<IWebElement> selectQuantity => driver.FindElements(By.CssSelector(".qty-select .plus"));



        //TO DO ??????????????????
        //public string GetItemName()
        //{
        //    return itemName;
        //}



        public void SelectItemQuantity()
        {
            selectQuantity[0].Click();
        }

        public void AddToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementAddToCartButtonSelector));
            elementAddToCartButton.Click();
        }

    }
}
