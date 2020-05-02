using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class ItemListing : BasePage
    {        
        private IList<IWebElement> itemNameListInItemListPage => driver.FindElements(By.CssSelector(".product_element .title span"));
        private IWebElement firstItemNameFromItemList => itemNameListInItemListPage[0];
        private IList<IWebElement> itemPriceListInItemListPage => driver.FindElements(By.CssSelector(".product_element .price"));
        private IWebElement firstItemPriceFromItemList => itemPriceListInItemListPage[0];
        private By itemAddToCartButtonListSelector = By.CssSelector(".product_element .buttons .btn-primary");
        private IList<IWebElement> itemAddToCartButtonList => driver.FindElements(itemAddToCartButtonListSelector);
        

        public string GetItemNameFromItemList()
        {
            return firstItemNameFromItemList.Text; 
        }

        public string GetItemPriceFromItemList()
        {
            return firstItemPriceFromItemList.Text;
        }

        public void AddToCartFirstItemFromItemList()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(itemAddToCartButtonListSelector));
            itemAddToCartButtonList[0].Click();
        }
    }
}
