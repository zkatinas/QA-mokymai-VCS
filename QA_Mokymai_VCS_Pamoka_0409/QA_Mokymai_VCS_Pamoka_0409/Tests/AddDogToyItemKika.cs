using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    public class AddDogToyItemKika : BaseTest
    {

        [SetUp]
        public void BeforeTest()
        {            
            popUpModal.ClosePopUpModal(); 
            kikaHomePage.header.ClickLoginIconButton();
            Thread.Sleep(2000);
            LoginWithtUser("testeris888@test.lt", "testeris888");
        }

        [Test]
        public void AddFirstDogToyItem()
        {

            Thread.Sleep(2000);
            kikaHomePage.header.AssertCartIconNumber("0");
            kikaHomePage.NavigateToDogToyList();

            item.AddToCartFirstItemFromItemList();
            kikaHomePage.header.GoToCart();
            cart.AssertItemCountInCart("1");
            //Assert iten mane, price, quantity ???
            kikaHomePage.header.AssertCartIconNumber("1");
            cart.RemoveItemFromCart();
            cart.AssertIfCartIsEmpty("Krepšelis yra tuščias");
            kikaHomePage.header.AssertCartIconNumber("0");

            kikaHomePage.header.ProfileMenuDisplay();
            kikaHomePage.header.LogOut();  

            Thread.Sleep(3000);
        }

    }
}
