using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System.Linq.Expressions;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class LoginModal
    {
        // Jei daug pakeitimu, tai parasom get'eri.
        private IWebDriver driver => Driver.Current;

        private const string LoginFormId = "login_form";
        private IWebElement elementEmailInput => driver.FindElement(By.CssSelector($"#dynamicModal #{LoginFormId} [name='email']"));
        private IWebElement elementPasswordInput => driver.FindElement(By.CssSelector($"#{LoginFormId} [name='password']"));
        private IWebElement elementLoginButton => driver.FindElement(By.CssSelector($"#{LoginFormId} .btn-primary"));
        private By elementLoginErrorMessageSelector = By.CssSelector("#customers_login .alert-dismissible");
        
        private IWebElement elementLoginErrorMessage
        { 
            get
            {
                try
                {
                    // Jei naudojam Implicit wait, pakeiciam jo trukme
                    //Driver.ChangeImplicitWait(1);
                    return driver.FindElement(elementLoginErrorMessageSelector);
                } 
                catch (NoSuchElementException)
                {
                    return null;
                }
                //finally
                //{
                //    Vel ijungiam Implicit wait musu pradine trukme
                //    Driver.TurnOnImplicitWait();
                //}
            }
        }
        

        private IWebElement elementLoginErrorMessageCloseButton => driver.FindElement(By.CssSelector("#customers_login .alert-dismissible .close"));

        public void Login (string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            ClickLoginFormButton();

            //bool noElement = true;
            //while (noElement)
            //{
            //    try
            //    {                    
            //        EnterEmail(email);                    
            //        EnterPassword(password);
            //        ClickLoginFormButton();
            //        noElement = false;
            //    }
            //    catch (WebDriverException)
            //    {
            //        noElement = true;
            //    }
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    try
            //    {
            //        WebDriverWait wait = new WebDriverWait(Driver.Current, System.TimeSpan.FromSeconds(5));
            //        wait.Until(d => elementEmailInput);
            //        EnterEmail(email);
            //        EnterPassword(password);
            //        ClickLoginFormButton();
            //        break;
            //    }
            //    catch (NoSuchElementException)
            //    {                    
            //    }
            //    catch(ElementNotInteractableException)
            //    {
            //    }
            //}
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

        public LoginModal IsLoginErrorMessageVisible()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Current, System.TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLoginErrorMessageSelector));
            Assert.IsNotNull(elementLoginErrorMessage, "Login error message is not visible!");
            return this;
        }

        public LoginModal ClickLoginErrorMessageCloseButton()
        {
            elementLoginErrorMessageCloseButton.Click();
            return this;
        }
        public LoginModal IsLoginErrorMessageNotVisible()
        {            
            Assert.IsNull(elementLoginErrorMessage, "Login error message is not closed!");
            return this;
        }

    }
}
