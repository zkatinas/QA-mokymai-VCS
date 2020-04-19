using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    class Cart
    {
        private IWebDriver driver;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement elementCart => driver.FindElement(By.Id("cart_info"));  
        

        //TO DO ??????????????????
        //Not used in assertion
        private string itemInCartName => driver.FindElement(By.CssSelector("#cart_items .product_name")).Text;
        private string itemInCartPriceWithTitle => driver.FindElement(By.CssSelector("#cart_items .price")).Text;
        private string[] list => itemInCartPriceWithTitle.Split("\n");
        private string itemInCartPrice => list[1];
        


        private IWebElement elementRemoveItemFromCart => driver.FindElement(By.CssSelector("#cart_items .cart_remove"));
        private IWebElement elementProfileMenuButton => driver.FindElement(By.CssSelector("#profile_menu .ico.ico-profile"));
        private By elementLogOutSelector = By.CssSelector("#profile_menu a[href='?logout']");
        private IWebElement elementLogOut => driver.FindElement(elementLogOutSelector);   
        

        public void GoToCart()
        {
            elementCart.Click();
        }

        public void RemoveItemFromCart()
        {
            elementRemoveItemFromCart.Click();
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
