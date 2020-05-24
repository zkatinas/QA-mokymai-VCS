using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using NUnit.Allure.Core;
using Allure.Commons;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class Cart : BasePage
    {               
        private IWebElement itemInCartNameWithCode => driver.FindElement(By.CssSelector("#cart_items .product_name"));        
        private IWebElement itemInCartDescriptionWithTitle => driver.FindElement(By.CssSelector("#cart_items .item_name"));        

        private IWebElement itemInCartPriceWithTitle => driver.FindElement(By.CssSelector("#cart_items .price"));        

        private IWebElement itemInCartQuantity => driver.FindElement(By.CssSelector(".value"));

        private IWebElement elementRemoveItemFromCart => driver.FindElement(By.CssSelector("#cart_items .cart_remove"));
        private By emptyCartMessageSelector = By.CssSelector("#cart_detailed .alert");
        private IWebElement emptyCartMessage => driver.FindElement(emptyCartMessageSelector);

        public void AssertItemNameAndItemInCartName(string itemName)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                string[] itemInCartNameWithCodeList = itemInCartNameWithCode.Text.Split("\r\n");
                string itemInCartName = itemInCartNameWithCodeList[0];
                Assert.AreEqual(itemName.ToLower(), itemInCartName.ToLower());
            }, "Assert selected item name with item in cart name");
        }

        public void AssertItemPriceAndItemInCartPrice(string itemPrice)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                string[] itemInCartPriceWithTitleList = itemInCartPriceWithTitle.Text.Split("\r\n");
                string itemInCartPrice = itemInCartPriceWithTitleList[1];
                Assert.AreEqual(itemPrice.ToLower(), itemInCartPrice.ToLower());
            }, "Assert selected item price with item in cart price");
        }

        public void AssertFirstItemNameFromListAndItemInCartName(string itemName)
        {
            string[] itemInCartNameWithCodeList = itemInCartNameWithCode.Text.Split("\r\n");
            string itemInCartNamePartOne = itemInCartNameWithCodeList[0];
            string[] itemInCartDescriptionWithTitleList = itemInCartDescriptionWithTitle.Text.Split("\r\n");
            string itemInCartNamePartSecond = itemInCartDescriptionWithTitleList[1];
            string itemInCartName = ($"{itemInCartNamePartOne} {itemInCartNamePartSecond}");
            Assert.AreEqual(itemName.ToLower(), itemInCartName.ToLower());
        }

        public void AssertFirstItemPriceFromListAndItemInCartPrice(string itemPrice)
        {
            string[] itemInCartPriceWithTitleList = itemInCartPriceWithTitle.Text.Split("\r\n");
            string itemInCartPrice = itemInCartPriceWithTitleList[1];
            Assert.AreEqual(itemPrice.ToLower(), itemInCartPrice.ToLower());
        }

        public void AssertItemCountInCart(string expectedItemNumber)
        {
            Assert.AreEqual(expectedItemNumber, itemInCartQuantity.Text);
        }

        public void AssertIfCartIsEmpty(string expectedMessage)
        {
            Driver.TurnOffImplicitWait();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyCartMessageSelector));
            Assert.AreEqual(expectedMessage, emptyCartMessage.Text);
            Driver.TurnOnImplicitWait();
        }

        public void RemoveItemFromCart()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                elementRemoveItemFromCart.Click();
            }, "Remove item from cart");
        }
    }
}
