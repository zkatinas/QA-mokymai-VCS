using OpenQA.Selenium;
using SeleniumEasy.Utilities;
using System.Collections.Generic;
using System;
using System.Threading;

namespace SeleniumEasy.Pages
{
    public class SearchResultPage
    {

        private IList<IWebElement> elementSearchResultList => 
            Driver.CurrentDriver.FindElements(By.CssSelector("#select2-book-search-results .select2-results__option"));       

        private IWebElement ItemNameElement(int index)
        {
            var parentElement = elementSearchResultList[index];
            Console.WriteLine($"found: {parentElement}");
            return parentElement.FindElement(By.CssSelector(".booklist span>span"));
        }

        public string GetItemTitle(int index)
        {
            Thread.Sleep(3000);
            return ItemNameElement(index).Text;
        }

        public ItemPage ClickOnItem(int index)
        {
            ItemNameElement(index).Click();
            return new ItemPage();
        }


    }
}
