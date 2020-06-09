using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using NUnit.Allure.Core;
using Allure.Commons;


namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    
    public class SearchPage : BasePage
    {
               
        IWebElement elementSearchField => driver.FindElement(By.CssSelector("#quick_search.active [name= 'search']"));
        IWebElement elementSearchButton => driver.FindElement(By.CssSelector("#quick_search [type= 'submit']"));

        IList<IWebElement> elementItemList => driver.FindElements(By.CssSelector(".product_element "));
        IList<IWebElement> elementItemTitleList => driver.FindElements(By.CssSelector(".product_element .title"));

        public SearchPage Search(string text)
        {
            AllureLifecycle.Instance.WrapInStep(() => 
            { 
                elementSearchField.SendKeys(text);
                elementSearchField.Click();
            },"Start the search");
            return this;
        }

        public void AssertSearchResultsContainsText(string text)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                var count = elementItemList.Count;
                Assert.IsTrue(count > 0, $"Search result count is: ${count}");
                Assert.AreEqual(count, elementItemTitleList.Count);

                foreach (var elementItemTitle in elementItemList)
                {
                    Assert.IsTrue(elementItemTitle.Text.Contains(text, StringComparison.CurrentCultureIgnoreCase),
                        $"Product title should contain: ${text}, but instead title is: ${elementItemTitle.Text}");
                }
            }, "Check if search result contains searchable text");
        }
    }
}
