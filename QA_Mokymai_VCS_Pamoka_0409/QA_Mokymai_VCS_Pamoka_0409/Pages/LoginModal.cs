using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    class LoginModal
    {

        private IWebDriver driver;

        public LoginModal(IWebDriver driver)
        {
            this.driver = driver;
        }

        private const string LoginFormId = "login_form";

        private IWebElement elementEmailInput => driver.FindElement(By.CssSelector($"#{LoginFormId} [name='email']"));
        private IWebElement elementPasswordInput => driver.FindElement(By.CssSelector($"#{LoginFormId} [name='password']"));
        private IWebElement elementLoginButton => driver.FindElement(By.CssSelector($"#{LoginFormId} .btn-primary"));

        public void Login (string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            ClickLoginFormButton();
        }
        
       //Pakeiciam "void" i pati "LoginModal" keliuose metoduose, gauname "chain" kviesdami siuos metodus
        public LoginModal EnterEmail(string email)
        {
            elementEmailInput.SendKeys(email);
            return this;
        }

        public LoginModal EnterPassword(string password)
        {
            elementPasswordInput.SendKeys(password);
            return this;
        }

        public LoginModal ClickLoginFormButton()
        {
            elementLoginButton.Click();
            return this;
        }
    }
}
