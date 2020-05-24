using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using NUnit.Allure.Core;
using Allure.Commons;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public class LoginModal
    {
        // Jei daug pakeitimu, tai parasom get'eri.$"#dynamicModal #{LoginFormId} [name='email']"
        private IWebDriver driver => Driver.Current;

        private const string LoginFormId = "login_form";
        //Su modal reikalingos klases "fade" ir in" - jos reiksi, kad elementas matomas
        private IWebElement elementEmailInput => driver.FindElement(By.CssSelector($"#dynamicModal.fade.in #{LoginFormId} [name='email']"));
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
                    Driver.ChangeImplicitWait(1);
                    return driver.FindElement(elementLoginErrorMessageSelector);
                } 
                catch (NoSuchElementException)
                {
                    return null;
                }
                finally
                {
                    //Vel ijungiam Implicit wait musu pradine trukme
                    Driver.TurnOnImplicitWait();
                }
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
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                elementEmailInput.SendKeys(email);                
            }, "User enter email");
            return this;
        }

        public LoginModal EnterPassword(string password)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                elementPasswordInput.SendKeys(password);
            }, "User enter password");
            return this;
        }

        public LoginModal ClickLoginFormButton()
        {
            AllureLifecycle.Instance.WrapInStep(() => 
            { 
                elementLoginButton.Click();
            }, "Click login button");  
            return this;
        }

        public LoginModal IsLoginErrorMessageVisible()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                WebDriverWait wait = new WebDriverWait(Driver.Current, System.TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLoginErrorMessageSelector));
                Assert.IsNotNull(elementLoginErrorMessage, "Login error message is not visible!");
            }, "Check if login error message is visible");
            return this;
        }

        public LoginModal ClickLoginErrorMessageCloseButton()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                elementLoginErrorMessageCloseButton.Click();
            }, "Close login error message");
            return this;
        }
        public LoginModal IsLoginErrorMessageNotVisible()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Assert.IsNull(elementLoginErrorMessage, "Login error message is not closed!");
            }, "Check if login message is NOT visible");
            return this;
        }
    }
}
