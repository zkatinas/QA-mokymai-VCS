using AutoPlus.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPlus.Pages
{
    public class SearchResultsPage
    {
        private IWebElement elementFirst => Driver.CurrentDriver.FindElement(By.CssSelector(".announcement-title"));

        public string GetProductName()
        {
            return elementFirst.Text;
        }

    }
}
