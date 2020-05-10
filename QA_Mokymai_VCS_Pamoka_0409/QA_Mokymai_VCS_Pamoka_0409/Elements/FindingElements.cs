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
        [SetUp]
        public void Start()
        {
            Driver.Init();
        }

        [Test]
        public void FindElementsKika()
        {
            KikaHomePage kikaHomePage = new KikaHomePage();
            LoginModal loginModal = new LoginModal();
            PopUpModal popUpModal = new PopUpModal();            
            
            Driver.Current.Url = "https://www.kika.lt/";
            popUpModal.ClosePopUpModal();
            kikaHomePage.Header.ClickLoginIconButton();
            Thread.Sleep(2000);
            loginModal.Login("testeris888@test.lt", "testeris888");
            Thread.Sleep(2000);

            var elementKikaWishListBubbleCount = Driver.Current.FindElement(By.CssSelector("#wishlist_info .cnt"));
            var e1 = elementKikaWishListBubbleCount.Text;
            Console.WriteLine($"Wishlist bubble element value is: {e1}");

            var elementKikaCartBubbleCount = Driver.Current.FindElement(By.CssSelector("#cart_info .cnt"));
            var e2 = elementKikaCartBubbleCount.Text;
            Console.WriteLine($"Cart bubble element value is: {e2}");

            Thread.Sleep(2000);
        }

        [Test]
        public void FindElementsScyCop()
        {
            Driver.Current.Url = "https://www.skycop.com/lt/";
            // 3rd element
            // Pagal "data-id" - skirtas auto testams            
            var elementDepartureINputField = Driver.Current.FindElement(By.CssSelector(".input-departure .ui-autocomplete-input"));
            elementDepartureINputField.SendKeys("vilni");
            Thread.Sleep(1000);

            // Style: display: block - rodomas; display : none - nerodomas
            var elementArrivalVNO = Driver.Current.FindElement(By.ClassName("ui-menu-item-wrapper"));
            var e4 = elementArrivalVNO.Text;
            Console.WriteLine($"Arrival airport name is: {e4}");

            var elementArrivalINputField = Driver.Current.FindElement(By.ClassName("input-destination"));
            var e5 = elementArrivalINputField.TagName;
            Console.WriteLine($"Arrival input field tag name is: {e5}");

            //6th element
            // .hero-form .primary ; pradeti nuo kazkokio tevinio su id, klase
            var elementClaimSubmitButton = Driver.Current.FindElement(By.ClassName("hero"));
            elementClaimSubmitButton.Click();

            //7th element
            Driver.Current.Url = "https://www.skycop.com/lt/";
            var elementKnowYourRightsDropdownList = Driver.Current.FindElements(By.ClassName("submenu-parent"));
            var elementKnowYourRightsDropdown = elementKnowYourRightsDropdownList[0];
            Actions action = new Actions(Driver.Current);
            action.MoveToElement(elementKnowYourRightsDropdown).Perform();

            var elementLateFlightCompensation = Driver.Current.FindElement(By.CssSelector(".menu-item-dropdown a[href='https://www.skycop.com/lt/veluojancio-skrydzio-kompensacija/']"));
            var e8 = elementLateFlightCompensation.GetAttribute("href");
            Console.WriteLine($"Late flight compensation url is: {e8}");

            Thread.Sleep(2000);
        }


        [Test]
        public void FindElementsVMI()
        {
            Driver.Current.Url = "https://sso.vmi.lt/sso/login";

            // pagal href pabaiga: eskis-acc ; gal dar pagal image
            var elementForDisabled = Driver.Current.FindElement(By.CssSelector("a[title = 'NEĮGALIESIEMS']"));
            var e9 = elementForDisabled.GetAttribute("title");
            Console.WriteLine($"The value of the element 'title' attribute is: {e9}");

            var elementLoginWithSecondTabOption = Driver.Current.FindElement(By.ClassName("tab2"));
            var e10 = elementLoginWithSecondTabOption.Text;
            Console.WriteLine($"The title of the second login tab option is: {e10}");

            // By.Linktext - kai tag'as "a" turi teksta           
            var elementLoginWithMedicalbank = Driver.Current.FindElement(By.LinkText("Medicinos bankas"));
            var e11 = elementLoginWithMedicalbank.Text;
            Console.WriteLine($"The title of the login via bank system option is: {e11}");

            Thread.Sleep(2000);
        }

        [Test]
        public void FindElementsUTest()
        {            
            Driver.Current.Url = "https://www.utest.com/";

            var elementProjectBoardOnLeftSideMenu = Driver.Current.FindElement(By.CssSelector("[name='Projects Board'] .nav-sidebar-item__text"));
            var e12 = elementProjectBoardOnLeftSideMenu.Text;
            Console.WriteLine($"The name of the element is: {e12}");

            // Kai yra -- ar __ gali reiksti, kad keisis
            // Pagal href arba pagal ui-sref
            var elementJoinUtestButton = Driver.Current.FindElement(By.ClassName("button--primary-semi-ghost"));
            var e13 = elementJoinUtestButton.Text;
            Console.WriteLine($"The name of the button is: {e13}");

            var elementHelpOption = Driver.Current.FindElement(By.CssSelector("[href='https://help.utest.com']"));
            var e14 = elementHelpOption.Text;
            Console.WriteLine($"The name of the element is: {e14}");

            Thread.Sleep(2000);
        }

        [Test]
        public void FindElementsGog()
        {
            Driver.Current.Url = "https://www.gog.com/";
            //15th element
            var elementCartIcon = Driver.Current.FindElement(By.CssSelector(".menu-tray [hook-test = 'menuCartButton']"));
            elementCartIcon.Click();            

            //16th element
            var elementSearchIcon = Driver.Current.FindElement(By.CssSelector(".menu-tray [hook-test = 'menuSearch']"));
            elementSearchIcon.Click();

            var elementProductPriceList = Driver.Current.FindElements(By.CssSelector(".product-tile__info .product-tile__price-discounted._price"));
            var elementProductPrice = elementProductPriceList[0];
            var e17 = elementProductPrice.Text;
            Console.WriteLine($"The text of the element is: {e17}");

            var elementProductPriceDiscountList = Driver.Current.FindElements(By.CssSelector(".product-tile__info .product-tile__discount"));
            var elementProductPriceDiscount = elementProductPriceDiscountList[0];
            var e18 = elementProductPriceDiscount.Text;
            Console.WriteLine($"The text of the element is: {e18}");

            var elementAddToCartIconList = Driver.Current.FindElements(By.CssSelector(".product-tile__info .product-tile__button"));
            var elementAddToCartIcon = elementAddToCartIconList[2];
            var e19 = elementAddToCartIcon.TagName;
            Console.WriteLine($"The tag name of the element is: {e19}");

            Thread.Sleep(2000);
        }

        [Test]
        public void FindElementsVinted()
        {
            Driver.Current.Url = "https://www.vinted.lt/";    
            Thread.Sleep(1000);
            var elementTopMenuClothesDropdown = Driver.Current.FindElement(By.CssSelector(".l-header__main [data-testid='search-bar-search-type']"));
            var e20 = elementTopMenuClothesDropdown.Text;
            Console.WriteLine($"The text of the element is: {e20}");

            var elementTopMenuSearchBar = Driver.Current.FindElement(By.CssSelector(".l-header__main #search_text"));
            var e21 = elementTopMenuSearchBar.TagName;
            Console.WriteLine($"The tag name of the element should be 'input': {e21}");

            var elementTopMenuClothesFormen = Driver.Current.FindElement(By.CssSelector("[href='/vyriski'].js-header-navigation-tab-item"));
            var e22 = elementTopMenuClothesFormen.Text;
            Console.WriteLine($"The text of the element is: {e22}");

            var elementTopMenuLogInButton = Driver.Current.FindElement(By.CssSelector(".l-header__actions [href='/member/signup/select_type"));
            var e23 = elementTopMenuLogInButton.Text;
            Console.WriteLine($"The text of the element is: {e23}");

            var elementTopMenuSellNowButton = Driver.Current.FindElement(By.CssSelector(".l-header__actions [href='/member/signup/start?ref_url=%2Fitems%2Fnew"));
            var e24 = elementTopMenuSellNowButton.Text;
            Console.WriteLine($"The text of the element is: {e24}");

            var elementUserImageInProductDescriptionInHomePageList = Driver.Current.FindElements(By.CssSelector(".feed-grid__item-content .c-cell__image"));
            var elementUserImageInProductDescriptionInHomePage = elementUserImageInProductDescriptionInHomePageList[0];
            var e25 = elementUserImageInProductDescriptionInHomePage.TagName;
            Console.WriteLine($"The tag name of the element is: {e25}");

            var elementSubTitleInProductDescriptionInHomePageList = Driver.Current.FindElements(By.CssSelector(".feed-grid__item-content .c-box__subtitle"));
            var elementSubTitleInProductDescriptionInHomePage = elementSubTitleInProductDescriptionInHomePageList[0];
            var e26 = elementSubTitleInProductDescriptionInHomePage.Text;
            Console.WriteLine($"The text of the element is: {e26}");

            var elementHeartIconInProductDescriptionInHomePageList = Driver.Current.FindElements(By.CssSelector(".feed-grid__item-content [data-icon-name='heart']"));
            var elementHeartIconInProductDescriptionInHomePage = elementHeartIconInProductDescriptionInHomePageList[0];
            var e27 = elementHeartIconInProductDescriptionInHomePage.TagName;
            Console.WriteLine($"The tag name of the element is: {e27}");

            //28th element
            var elementItemPhotoInProductDescriptionInHomePageList = Driver.Current.FindElements(By.CssSelector(".feed-grid__item-content .c-box__image"));
            var elementItemPhotoInProductDescriptionInHomePage = elementItemPhotoInProductDescriptionInHomePageList[0];
            elementItemPhotoInProductDescriptionInHomePage.Click();   

            Thread.Sleep(2000);
        }

        [Test]
        public void FindElementsDelfi()
        {
            Driver.Current.Url = "https://www.delfi.lt/";
            var elementTopMenuLanguageSelect = Driver.Current.FindElement(By.CssSelector("#header-links1 [href='//www.delfi.lt/']"));
            var e29 = elementTopMenuLanguageSelect.Text;
            Console.WriteLine($"The text of the element is: {e29}");

            var elementTopMenuLogInButton = Driver.Current.FindElement(By.Id("_login"));
            var e30 = elementTopMenuLogInButton.TagName;
            Console.WriteLine($"The tag name of the element is: {e30}");

            Thread.Sleep(2000);
            Actions action = new Actions(Driver.Current);
            action.MoveToElement(Driver.Current.FindElement(By.ClassName("header-weather"))).Perform();
            var elementTopMenuLocationDropdownNida = Driver.Current.FindElement(By.CssSelector(".header-weather [data-city='Nida']"));
            var e31 = elementTopMenuLocationDropdownNida.TagName;
            Console.WriteLine($"The tag name of the element is: {e31}");

            var elementTopNavigationHomeLink = Driver.Current.FindElement(By.CssSelector(".header-nav-container [href='//www.delfi.lt/bustas/']"));
            var e32 = elementTopNavigationHomeLink.Text;
            Console.WriteLine($"The text of the element is: {e32}");

            var elementArticleTitleList = Driver.Current.FindElements(By.CssSelector("h3.headline-title"));
            var elementTitleOfFifthArticle = elementArticleTitleList[4];
            var e33 = elementTitleOfFifthArticle.Text;
            Console.WriteLine($"The text of the element is: {e33}");

            Thread.Sleep(2000);
        }

        [Test]
        public void FindElementsTrafiVilnius()
        {
            Driver.Current.Url = "https://web.trafi.com/lt/vilnius";
            var elementEnterDepartureLocation = Driver.Current.FindElement(By.CssSelector(".c-input__content [placeholder='Pasirink išvykimo vietą']"));
            var e34 = elementEnterDepartureLocation.TagName;
            Console.WriteLine($"The tag name of the element is: {e34}");

            var elementEnterDestinantionLocation = Driver.Current.FindElement(By.CssSelector(".c-input__content [placeholder='Pasirink atvykimo vietą']"));
            var e35 = elementEnterDestinantionLocation.TagName;
            Console.WriteLine($"The tag name of the element is: {e35}");
            
            var elementSelectHomeLocation = Driver.Current.FindElement(By.XPath("//div[contains(text(), 'Pasirink namų vietą')]"));           
            var e36 = elementSelectHomeLocation.Text;
            Console.WriteLine($"The text of the element is: {e36}");

            var elementGooglePlayStore = Driver.Current.FindElement(By.CssSelector("[href='https://l.trafi.com/web_to_playstore']"));
            var e37 = elementGooglePlayStore.TagName;
            Console.WriteLine($"The tag name of the element is: {e37}");

            //Kaip parinkti masina zemelapyje?
            //$$(".map-popup__container .c-cell__text")

            Thread.Sleep(2000);
        }


        [TearDown]
        public void TearDown()
        {
            Driver.Current.Quit();
        }

    }
}
