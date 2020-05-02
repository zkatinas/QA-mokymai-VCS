using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using QA_Mokymai_VCS_Pamoka_0409.Utils;


namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class PageMenuSection
    {
        
        private IWebDriver driver => Driver.Current;

        private IWebElement elementDogAllItemCategory => driver.FindElement(By.CssSelector("#mega_menu .dog .title"));
        private IWebElement elementDogToyItemCategory => driver.FindElement(By.CssSelector("#mega_menu .dog.active.hover [title = 'Žaislai']"));
        
        public KikaHeaderSection header => new KikaHeaderSection();
        public LoginModal loginModal => new LoginModal();


        public void NavigateToDogToyList()
        {            
            Actions action = new Actions(driver);
            action.MoveToElement(elementDogAllItemCategory).Perform();
            elementDogToyItemCategory.Click();
        }
        
    }
}
