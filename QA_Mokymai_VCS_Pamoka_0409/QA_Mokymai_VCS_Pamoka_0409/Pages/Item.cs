using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class Item : BasePage
    {
        
        //TO DO ??????????????????
        //Not used in assertion
        private string itemNameInItemPage => driver.FindElement(By.CssSelector(".summary_wrp h1")).Text;
        private IList<IWebElement> itemPriceList => driver.FindElements(By.CssSelector(".prices .price"));
        private string itemPriceInItemPage => itemPriceList[0].Text;

        // How to assert - different class???
        private IList<IWebElement> itemNameListInItemListPage => driver.FindElements(By.CssSelector(".product_element .title"));
        private string firstItemNameFromItemList => itemNameListInItemListPage[0].Text;
        private IList<IWebElement> itemPriceListInItemListPage => driver.FindElements(By.CssSelector(".product_element .price"));
        private string firstItemPriceFromItemList => itemPriceListInItemListPage[0].Text;

        private By elementAddToCartButtonSelector = By.Id("add2cart_button");
        private By itemAddToCartButtonListSelector = By.CssSelector(".product_element .buttons .btn-primary");
        private IWebElement elementAddToCartButton => driver.FindElement(elementAddToCartButtonSelector);
        private IList<IWebElement> selectItemQuantity => driver.FindElements(By.CssSelector(".qty-select .plus"));
        private IList<IWebElement> itemAddToCartButtonList => driver.FindElements(itemAddToCartButtonListSelector);

        //TO DO ??????????????????
        //public string GetItemName()
        //{
        //    return itemName;
        //}



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

        public void AddToCartFirstItemFromItemList()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(itemAddToCartButtonListSelector));
            itemAddToCartButtonList[0].Click();
        }
    }
}
