using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Mokymai_VCS_Pamoka_0409.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    public class LoginTestKika : BaseTest
    {
        
        [Test]
        public void TestLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            Thread.Sleep(2000);
            //Suranda pop lango "close" mygtuka ir ji paspaudzia
            //driver.FindElement(By.CssSelector("#editable_popup[style='display: block;'] .close")).Click();
            //IWebElement elementPopupCloseButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#editable_popup[style*='display: block;'] .close")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementPopupCloseButtonSelector));            
            //elementPopupCloseButton.Click();
            popUpModal.ClosePopUpModal();

            Thread.Sleep(2000);
            //Randame "login" mygtuka pagal klase "need2login"
            //IWebElement elementLoginIconButton = driver.FindElement(By.CssSelector(".need2login"));            
            kikaHomePage.header.ClickLoginIconButton();

            Thread.Sleep(1500);
            //Randame "email" laukeli pagal formos "id" ir pagal laukelio "name"
            //IWebElement elementEmailInput = driver.FindElement(By.CssSelector($"#{LoginFormId} [name='email']"));            
            loginModal.EnterEmail("testeris888@test.lt");

            //Randame "password" laukeli pagal formos "id" ir pagal laukelio "name"
            //IWebElement elementPasswordInput = driver.FindElement(By.CssSelector($"#{LoginFormId} [name='password']"));            
            loginModal.EnterPassword("testeris888");

            //Randame "Prisijungti" mygtuka pagal formos "id" ir pagal mygtuko klase "btn-primary"
            //IWebElement elementLoginButton = driver.FindElement(By.CssSelector("#login_form .btn-primary"));            
            loginModal.ClickLoginFormButton();

            // Galima naudoti bendra metoda
            //loginModal.Login("testeris888@test.lt", "testeris888");

            //Galima naudoti "chain"
            //loginModal.EnterEmail("testeris888@test.lt").EnterEmail("testeris888").ClickLoginFormButton();

            Thread.Sleep(1000);
            //IWebElement elementPopupCloseButtonAfterLogin = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#editable_popup[style*='display: block;'] .close")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementPopupCloseButtonSelector));
            //elementPopupCloseButtonAfterLogin.Click();
            popUpModal.ClosePopUpModal();

            Thread.Sleep(1000);
            //IWebElement elementUserIconAfterLogin = driver.FindElement(By.CssSelector("#profile_menu .ico-profile"));
            //elementUserIconAfterLogin.Click();
            //
            //Thread.Sleep(1000);

            //Patikrinti, ar prisijunges
            //string userLogged = driver.FindElement(By.CssSelector("#profile_menu.dropdown .dropdown-menu[style*='display: block;'] a[href='https://www.kika.lt/paskyra/uzsakymai/']")).Text;
            //string manoUzsakymai = "Mano užsakymai";
            //Assert.AreEqual(userLogged, manoUzsakymai);
            //Thread.Sleep(2000);
        }

    }
}
