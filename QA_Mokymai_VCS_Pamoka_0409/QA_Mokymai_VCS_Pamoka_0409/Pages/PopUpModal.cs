using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class PopUpModal : BasePage
    {       
        public PopUpModal(IWebDriver driver) : base(driver)  {   }

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
