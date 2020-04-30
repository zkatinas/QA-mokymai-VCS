using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class Cart : BasePage
    {
       
        //TO DO ??????????????????
        //Not used in assertion
        private string itemInCartNameWithCode => driver.FindElement(By.CssSelector("#cart_items .product_name")).Text;
        private string[] itemInCartNameWithCodeList => itemInCartPriceWithTitle.Split("\r");
        private string itemInCartName => itemInCartNameWithCodeList[0];
        private string itemInCartPriceWithTitle => driver.FindElement(By.CssSelector("#cart_items .price")).Text;
        private string[] itemInCartPriceWithTitleList => itemInCartPriceWithTitle.Split("\r");
        private string itemInCartPrice => itemInCartPriceWithTitleList[1];

        private string itemInCartQuantity => driver.FindElement(By.CssSelector(".value")).Text;


        private IWebElement elementRemoveItemFromCart => driver.FindElement(By.CssSelector("#cart_items .cart_remove"));
        private By emptyCartMessageSelector = By.CssSelector("#cart_detailed .alert");
        private string emptyCartMessage => driver.FindElement(emptyCartMessageSelector).Text;        


        public void AssertItemCountInCart(string expectedItemNumber)
        {
            Assert.AreEqual(expectedItemNumber, itemInCartQuantity);
        }

        public void AssertIfCartIsEmpty(string expectedMessage)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(emptyCartMessageSelector));
            Assert.AreEqual(expectedMessage, emptyCartMessage);
        }

        public void RemoveItemFromCart()
        {
            elementRemoveItemFromCart.Click();
        }
        
    }
}
