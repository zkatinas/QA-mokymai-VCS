using NUnit.Framework;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    [Parallelizable]
    public class AddDogToyItemKika : BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {            
            popUpModal.ClosePopUpModal();            
            kikaHomePage.Header.ClickLoginIconButton();
            // Nespeja suvesti email ir password
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

            var itemFromListName = itemListing.GetItemNameFromItemList();            
            var itemFromListPrice = itemListing.GetItemPriceFromItemList();

            itemListing.AddToCartFirstItemFromItemList();
            kikaHomePage.Header.ClickOnCartIcon();
            cart.AssertItemCountInCart("1");
            //Assert item name, price, quantity ???
            cart.AssertFirstItemNameFromListAndItemInCartName(itemFromListName);
            cart.AssertFirstItemPriceFromListAndItemInCartPrice(itemFromListPrice);
            kikaHomePage.Header.AssertCartIconNumber("1");
            cart.RemoveItemFromCart();
            cart.AssertIfCartIsEmpty("Krepšelis yra tuščias");

            // Perkraunam puslapi
            Driver.RefreshPage();
            kikaHomePage.Header.AssertCartIconNumber("0");

            kikaHomePage.Header.ClickOnProfileMenuIcon();
            kikaHomePage.Header.LogOut();  

            Thread.Sleep(3000);
        }

    }
}
