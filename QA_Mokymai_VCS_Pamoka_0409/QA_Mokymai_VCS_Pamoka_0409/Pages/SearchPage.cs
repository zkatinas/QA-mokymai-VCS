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


        public void Search(string text)
        {
            elementSearchField.SendKeys(text);
            elementSearchField.Click();
        }
    }

}
