using NUnit.Allure.Core;
using NUnit.Framework;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    [AllureNUnit]    
    [Parallelizable]
    public class LoginTestKika : BaseTest
    {
        [Test]
        public void TestLogin()
        {            
            popUpModal.ClosePopUpModal();                                   
            kikaHomePage.Header.ClickLoginIconButton();
            Thread.Sleep(1500);
            loginModal.EnterEmail("testeris888@test.lt");
            loginModal.EnterPassword("testeris888");
            loginModal.ClickLoginFormButton();
            //LoginWithtUser("testeris888@test.lt", "testeris888");

            // Galima naudoti bendra metoda
            //loginModal.Login("testeris888@test.lt", "testeris888");

            //Galima naudoti "chain"
            //loginModal.EnterEmail("testeris888@test.lt").EnterEmail("testeris888").ClickLoginFormButton();  


            //Patikrinti, ar prisijunges              
            kikaHomePage.Header.CheckIfUserIsLogged();
            Thread.Sleep(2000);
        }

    }
}
