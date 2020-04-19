using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    class KikaHomePage
    {
        private IWebDriver driver;
        public KikaHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }        

        private IWebElement elementLoginIconButton => driver.FindElement(By.CssSelector(".need2login"));
        private IList<IWebElement> visibleItems => driver.FindElements(By.CssSelector(".owl-item.active"));
        //private string itemCountInCartBeforeBuy => driver.FindElement(By.CssSelector("em.cnt")).Text;       
        //private string zeroItemInCart = "0";
        //private string itemCountInCartAfterBuy => driver.FindElement(By.CssSelector("em.cnt")).Text;
        //private string oneItemInCart = "1";
        private string itemCountInCart => driver.FindElement(By.CssSelector("em.cnt")).Text;

        public void ClickLoginIconButton()
        {
            elementLoginIconButton.Click();
        }

        public void ClickFirstItem()
        {
            visibleItems[0].Click();
        }

        public void AssertCartIconNumber(string itemNumber)
        {
            Assert.AreEqual(itemNumber, itemCountInCart);
        }

    }
}
