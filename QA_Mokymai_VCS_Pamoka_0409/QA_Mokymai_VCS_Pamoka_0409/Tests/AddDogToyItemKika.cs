using NUnit.Framework;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    public class AddDogToyItemKika : BaseTest
    {

        [SetUp]
        public void BeforeTest()
        {            
            popUpModal.ClosePopUpModal();
            Thread.Sleep(2000);
            kikaHomePage.Header.ClickLoginIconButton();
            Thread.Sleep(2000);
            LoginWithtUser("testeris888@test.lt", "testeris888");
        }

        [Test]
        public void AddFirstDogToyItem()
        {

            Thread.Sleep(2000);
            kikaHomePage.Header.AssertCartIconNumber("0");
            pageMenuSection.NavigateToDogToyList();

            // Naviguojam tiesiai per sunu zaislu url:
            //Navigation.GoToDogToysPage();

            item.AddToCartFirstItemFromItemList();
            kikaHomePage.Header.GoToCart();
            cart.AssertItemCountInCart("1");
            //Assert item mane, price, quantity ???
            kikaHomePage.Header.AssertCartIconNumber("1");
            cart.RemoveItemFromCart();
            cart.AssertIfCartIsEmpty("Krepšelis yra tuščias");
            kikaHomePage.Header.AssertCartIconNumber("0");

            kikaHomePage.Header.ProfileMenuDisplay();
            kikaHomePage.Header.LogOut();  

            Thread.Sleep(3000);
        }

    }
}
