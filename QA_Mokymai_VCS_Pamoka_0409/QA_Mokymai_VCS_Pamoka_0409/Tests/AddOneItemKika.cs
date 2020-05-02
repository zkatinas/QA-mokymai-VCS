using NUnit.Framework;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    public class AddOneItemKika : BaseTest
    {
        
        [SetUp]
        public void Before()
        {
            //Kai tinka default user:
            //LoginWithDefaultUser();
            popUpModal.ClosePopUpModal();            
            kikaHomePage.Header.ClickLoginIconButton();
            Thread.Sleep(2000);
            LoginWithtUser("testeris888@test.lt", "testeris888");
        }                
        
        [Test]
        public void AddFirstFoodInList()
        {               
            Thread.Sleep(2000);
            //Patikriname, ar krepselyje nera prekiu            
            kikaHomePage.Header.AssertCartIconNumber("0");

            //Parenkame pirma rodoma item                        
            kikaHomePage.ClickFirstItem();

            var itemFromListName = item.GetItemName();
            var itemFromListPrice = item.GetItemPrice();  

            //Parenkame item kieki            
            item.SelectItemQuantity();
            item.AddToCart();

            //Patikriname, ar item idetas i krepseli
            Thread.Sleep(3500);            
            kikaHomePage.Header.AssertCartIconNumber("1");
            kikaHomePage.Header.ClickOnCartIcon();

            cart.AssertItemNameAndItemInCartName(itemFromListName);
            cart.AssertItemPriceAndItemInCartPrice(itemFromListPrice);

            cart.RemoveItemFromCart();
            Thread.Sleep(2000);
            kikaHomePage.Header.ClickOnProfileMenuIcon();
            kikaHomePage.Header.LogOut();

            Thread.Sleep(3000);
        }


    }
}
