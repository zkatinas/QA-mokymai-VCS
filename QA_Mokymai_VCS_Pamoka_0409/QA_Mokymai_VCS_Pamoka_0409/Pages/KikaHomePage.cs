using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System.Collections.Generic;


namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class KikaHomePage : BasePage
    {        
        //Konstruktoriaus nebereikia -default pagal BasePage klase (su"base") ir cia uztenka tuscio konstruktoriaus              
                
        private IList<IWebElement> visibleItems => driver.FindElements(By.CssSelector(".owl-item.active"));        
                
        public LoginModal loginModal => new LoginModal();

        public void ClickFirstItem()
        {
            visibleItems[0].Click();
        }        

        public KikaHomePage Login(User user)
        {
            Header.ClickLoginIconButton();
            //Login metodui paduodam kintamuosius be reiksmiu ???
            loginModal.Login(user.Username, user.Password);
            return this;
        }
    }
}
