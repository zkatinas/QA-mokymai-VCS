using OpenQA.Selenium;
using SeleniumEasy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumEasy.Pages
{
    public class ItemPage
    {
        private IWebElement elementItemName => Driver.CurrentDriver.FindElement(By.CssSelector("[itemprop = 'name']"));

        public string GetItemName()
        {
            return elementItemName.Text;
        }
        
    }
}
