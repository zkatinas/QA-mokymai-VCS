using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
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
            popUpModal.ClosePopUpModal();

            Thread.Sleep(2000);                       
            kikaHomePage.header.ClickLoginIconButton();

            Thread.Sleep(1500);                      
            loginModal.EnterEmail("testeris888@test.lt");          
            loginModal.EnterPassword("testeris888");           
            loginModal.ClickLoginFormButton();

            // Galima naudoti bendra metoda
            //loginModal.Login("testeris888@test.lt", "testeris888");

            //Galima naudoti "chain"
            //loginModal.EnterEmail("testeris888@test.lt").EnterEmail("testeris888").ClickLoginFormButton();  

            Thread.Sleep(2000);            

            //Patikrinti, ar prisijunges
            //string userLogged = driver.FindElement(By.CssSelector("#profile_menu.dropdown .dropdown-menu[style*='display: block;'] a[href='https://www.kika.lt/paskyra/uzsakymai/']")).Text;
            //string manoUzsakymai = "Mano užsakymai";
            //Assert.AreEqual(userLogged, manoUzsakymai);
            //Thread.Sleep(2000);
        }

    }
}
