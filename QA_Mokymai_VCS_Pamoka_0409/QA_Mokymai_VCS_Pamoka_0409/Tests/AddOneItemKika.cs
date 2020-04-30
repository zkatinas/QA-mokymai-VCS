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
            Thread.Sleep(2000);
            kikaHomePage.Header.ClickLoginIconButton();
            Thread.Sleep(2000);            
            LoginWithtUser("testeris888@test.lt", "testeris888");
        }
                
        
        [Test]
        public void AddFirstFoodInList()
        {
            //WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));   
            Thread.Sleep(2000);
            //Patikriname, ar krepselyje nera prekiu            
            kikaHomePage.Header.AssertCartIconNumber("0");

            //Parenkame pirma rodoma item                        
            kikaHomePage.ClickFirstItem();


            //TO DO ?????????????????????

            //string itemName = driver.FindElement(By.CssSelector(".summary_wrp h1")).Text;
            //item.GetItemName();
            //IList<IWebElement> itemPriceList = driver.FindElements(By.CssSelector(".prices .price"));
            //string itemPrice = itemPriceList[0].Text;



            //Parenkame item kieki            
            item.SelectItemQuantity();
            item.AddToCart();

            //Patikriname, ar item idetas i krepseli
            Thread.Sleep(3500);            
            kikaHomePage.Header.AssertCartIconNumber("1");
            kikaHomePage.Header.GoToCart();


            // ???????????????????
            //TO DO: assert item name/price with item in cart name/price - variables from 2

            //string itemInCartName = driver.FindElement(By.CssSelector("#cart_items .product_name")).Text;
            //string itemInCartPriceWithTitle = driver.FindElement(By.CssSelector("#cart_items .price")).Text;
            //string[] list = itemInCartPriceWithTitle.Split("\n");            
            //string itemInCartPrice = list[1];           
            //Assert.AreEqual(itemName, itemInCartName);
            //Assert.AreEqual(itemPrice, itemInCartPrice);


            cart.RemoveItemFromCart();
            Thread.Sleep(2000);
            kikaHomePage.Header.ProfileMenuDisplay();
            kikaHomePage.Header.LogOut();

            Thread.Sleep(3000);
        }


    }
}
