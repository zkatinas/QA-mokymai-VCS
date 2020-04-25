using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System.Collections.Generic;


namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class KikaHomePage : BasePage
    {        
        //Konstruktoriu gaunam is BasePage klases (su"base") ir cia uztenka tuscio konstruktoriaus
        public KikaHomePage(IWebDriver driver) : base(driver) { }        
                
        private IList<IWebElement> visibleItems => driver.FindElements(By.CssSelector(".owl-item.active"));

        private IWebElement elementDogAllItemCategory => driver.FindElement(By.CssSelector("#mega_menu .dog .title"));
        private IWebElement elementDogToyItemCategory => driver.FindElement(By.CssSelector("#mega_menu .dog.active.hover [title = 'Žaislai']"));

        public KikaHeaderSection header => new KikaHeaderSection(driver);
        public LoginModal loginModal => new LoginModal(driver);

        public void ClickFirstItem()
        {
            visibleItems[0].Click();
        }

        public void NavigateToDogToyList()
        {
            // To DO
            Actions action = new Actions(driver);
            action.MoveToElement(elementDogAllItemCategory).Perform();
            elementDogToyItemCategory.Click();
        }

       public KikaHomePage Login(User user)
        {
            header.ClickLoginIconButton();
            //Login metodui paduodam kintamuosius be reiksmiu ???
            loginModal.Login(user.Username, user.Password);            
            return this;
        }
    }
}
