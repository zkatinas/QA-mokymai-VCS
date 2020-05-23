using Allure.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using NUnit.Allure.Core;


namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class PopUpModal
    {

        private By elementPopupCloseButtonSelector = By.CssSelector("#editable_popup[style*='display: block;'] .close");

        //"=>" tas pats, kas "get"
        private IWebElement elementPopupCloseButton => Driver.Current.FindElement(elementPopupCloseButtonSelector);

        public void ClosePopUpModal()
        {
            // WrapInStep - itraukiam i report'a
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Driver.TurnOffImplicitWait();
                WebDriverWait wait = new WebDriverWait(Driver.Current, System.TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementPopupCloseButtonSelector));
                elementPopupCloseButton.Click();
                Driver.TurnOnImplicitWait();
            }, "Closes pop-up modal");
        }

    }
}
