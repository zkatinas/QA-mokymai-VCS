using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System.Collections.Generic;
using NUnit.Allure.Core;
using Allure.Commons;


namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class KikaHomePage : BasePage
    {        
        //Konstruktoriaus nebereikia -default pagal BasePage klase (su"base") ir cia uztenka tuscio konstruktoriaus              
                
        private IList<IWebElement> visibleItems => driver.FindElements(By.CssSelector(".owl-item.active"));        
                
        public LoginModal loginModal => new LoginModal();

        public void ClickFirstItem()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                visibleItems[0].Click();
            }, "Click first visible item from the list");
        }        

        public KikaHomePage Login(User user)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Header.ClickLoginIconButton();
                //Login metodui paduodam kintamuosius be reiksmiu ???
                loginModal.Login(user.Username, user.Password);
            }, "Complete login");
            return this;
        }
    }
}
