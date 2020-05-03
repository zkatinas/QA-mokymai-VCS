using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using QA_Mokymai_VCS_Pamoka_0409.Pages;
using QA_Mokymai_VCS_Pamoka_0409.Tests;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Elements
{
    public class FindingElements
    {

        [Test]
        public void FindElementsTests()
        {
            KikaHomePage kikaHomePage = new KikaHomePage();
            LoginModal loginModal = new LoginModal();
            PopUpModal popUpModal = new PopUpModal();

            Driver.Init();
            
            // Kika
            //Driver.Current.Url = "https://www.kika.lt/";
            //popUpModal.ClosePopUpModal();
            //kikaHomePage.Header.ClickLoginIconButton();            
            //Thread.Sleep(2000);
            //loginModal.Login("testeris888@test.lt", "testeris888");
            //Thread.Sleep(2000);

            //var elementKikaWishListBubbleCount = Driver.Current.FindElement(By.CssSelector("#wishlist_info .cnt"));
            //var e1 = elementKikaWishListBubbleCount.Text;
            //Console.WriteLine($"Wishlist bubble element value is: {e1}");

            //var elementKikaCartBubbleCount = Driver.Current.FindElement(By.CssSelector("#cart_info .cnt"));
            //var e2 = elementKikaCartBubbleCount.Text;
            //Console.WriteLine($"Cart bubble element value is: {e2}");


            // Skycop
            //Driver.Current.Url = "https://www.skycop.com/lt/";
            //// 3rd element
            //var elementDepartureINputField = Driver.Current.FindElement(By.CssSelector(".input-departure .ui-autocomplete-input"));
            //elementDepartureINputField.SendKeys("vilni");
            //Thread.Sleep(1000);

            //var elementArrivalVNO = Driver.Current.FindElement(By.ClassName("ui-menu-item-wrapper"));
            //var e4 = elementArrivalVNO.Text;
            //Console.WriteLine($"Arrival airport name is: {e4}");

            //var elementArrivalINputField = Driver.Current.FindElement(By.ClassName("input-destination"));
            //var e5 = elementArrivalINputField.TagName;
            //Console.WriteLine($"Arrival input field tag name is: {e5}");

            ////6th element
            //var elementClaimSubmitButton = Driver.Current.FindElement(By.ClassName("hero"));
            //elementClaimSubmitButton.Click();

            ////7th element
            //Driver.Current.Url = "https://www.skycop.com/lt/";
            //var elementKnowYourRightsDropdownList = Driver.Current.FindElements(By.ClassName("submenu-parent"));
            //var elementKnowYourRightsDropdown = elementKnowYourRightsDropdownList[0];
            //Actions action = new Actions(Driver.Current);
            //action.MoveToElement(elementKnowYourRightsDropdown).Perform();

            //var elementLateFlightCompensation = Driver.Current.FindElement(By.CssSelector(".menu-item-dropdown a[href='https://www.skycop.com/lt/veluojancio-skrydzio-kompensacija/']"));
            //var e8 = elementLateFlightCompensation.GetAttribute("href");
            //Console.WriteLine($"Late flight compensation url is: {e8}");


            //VMI
            //Driver.Current.Url = "https://sso.vmi.lt/sso/login";
            
            //var elementForDisabled = Driver.Current.FindElement(By.CssSelector("a[title = 'NEĮGALIESIEMS']"));
            //var e9 = elementForDisabled.GetAttribute("title");
            //Console.WriteLine($"The value of the element 'title' attribute is: {e9}");

            //var elementLoginWithSecondTabOption = Driver.Current.FindElement(By.ClassName("tab2"));
            //var e10 = elementLoginWithSecondTabOption.Text;
            //Console.WriteLine($"The title of the second login tab option is: {e10}");

            //var elementLoginWithMedicalbank = Driver.Current.FindElement(By.CssSelector(".fieldsContainer>a:nth-of-type(6)"));
            //var e11 = elementLoginWithMedicalbank.Text;
            //Console.WriteLine($"The title of the login via bank system option is: {e11}");


            //uTest
            Driver.Current.Url = "https://www.utest.com/";

            var elementProjectBoardOnLeftSideMenu = Driver.Current.FindElement(By.CssSelector("[name='Projects Board'] .nav-sidebar-item__text"));
            var e12 = elementProjectBoardOnLeftSideMenu.Text;
            Console.WriteLine($"The name of the element is: {e12}");

            var elementJoinUtestButton = Driver.Current.FindElement(By.ClassName("button--primary-semi-ghost"));
            var e13 = elementJoinUtestButton.Text;
            Console.WriteLine($"The name of the button is: {e13}");

            var elementHelpOption = Driver.Current.FindElement(By.CssSelector("[href='https://help.utest.com']"));
            var e14 = elementHelpOption.Text;
            Console.WriteLine($"The name of the element is: {e14}");

            Thread.Sleep(2000);

        }
    }
}
