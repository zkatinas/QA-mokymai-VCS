using OpenQA.Selenium;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System.Collections.Generic;


namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class KikaHomePage : BasePage
    {        
        //Konstruktoriu gaunam is BasePage klases (su"base") ir cia uztenka tuscio konstruktoriaus
        public KikaHomePage(IWebDriver driver) : base(driver) { }        
                
        private IList<IWebElement> visibleItems => driver.FindElements(By.CssSelector(".owl-item.active"));

        public KikaHeaderSection header => new KikaHeaderSection(driver);
        public LoginModal login => new LoginModal(driver);

        public void ClickFirstItem()
        {
            visibleItems[0].Click();
        }

       public KikaHomePage Login(User user)
        {
            header.ClickLoginIconButton();
            login.Login(user.Username, user.Password);            
            return this;
        }
    }
}
