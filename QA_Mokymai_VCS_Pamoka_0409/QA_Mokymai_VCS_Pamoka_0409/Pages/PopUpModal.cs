using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    class PopUpModal
    {
        private IWebDriver driver;        

        public PopUpModal(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By elementPopupCloseButtonSelector = By.CssSelector("#editable_popup[style*='display: block;'] .close");        

        //"=>" tas pats, kas "get"
        private IWebElement elementPopupCloseButton => driver.FindElement(elementPopupCloseButtonSelector);
        //private IWebElement elementPopupCloseButtonAfterLogin => driver.FindElement(elementPopupCloseButtonSelector);


        public void ClosePopUpModal()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementPopupCloseButtonSelector));
            elementPopupCloseButton.Click();
        }

    }
}
