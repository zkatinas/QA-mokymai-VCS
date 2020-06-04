using OpenQA.Selenium;
using SeleniumEasy.Utilities;


namespace SeleniumEasy.Pages
{
    public class HomePage
    {

        private IWebElement elementSearchByTitle => Driver.CurrentDriver.FindElement(By.Id("select2-book-search-container"));
        private IWebElement elementSearchByTitleInputField => Driver.CurrentDriver.FindElement(By.CssSelector(".select2-dropdown .select2-search__field"));        

        public SearchResultPage SearchByTitle(string title)
        {
            elementSearchByTitle.Click();
            elementSearchByTitleInputField.SendKeys(title);
            return new SearchResultPage();
        }



    }
}
