using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class SearchPage : BasePage
    {
        public  SearchPage(IWebDriver driver) : base(driver)
        {
        }
                
        IWebElement elementSearchField => driver.FindElement(By.CssSelector("#quick_search.active [name= 'search']"));
        IWebElement elementSearchButton => driver.FindElement(By.CssSelector("#quick_search [type= 'submit']"));

        IList<IWebElement> elementItemList => driver.FindElements(By.CssSelector(".product_element "));
        IList<IWebElement> elementItemTitleList => driver.FindElements(By.CssSelector(".product_element .title"));

        public SearchPage Search(string text)
        {
            elementSearchField.SendKeys(text);
            elementSearchField.Click();
            return this;
        }

        public void AssertSearchResultsContainsText(string text)
        {
            var count = elementItemList.Count;
            Assert.IsTrue(count > 0, $"Search result count is: ${count}");
            Assert.AreEqual(count, elementItemTitleList.Count);
           
            foreach (var elementItemTitle in elementItemList)
            {
                Assert.IsTrue(elementItemTitle.Text.Contains(text, StringComparison.CurrentCultureIgnoreCase), 
                    $"Product title should contain: ${text}, but instead title is: ${elementItemTitle.Text}");
            }
        }
    }

}
