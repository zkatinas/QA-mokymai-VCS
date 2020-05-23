using NUnit.Allure.Core;
using NUnit.Framework;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    [AllureNUnit]
    [Parallelizable]
    public class LoginBadUserKika : BaseTest
    {
        [Test]
        public void TestLoginEmpty()
        {
            popUpModal.ClosePopUpModal();            
            kikaHomePage.Header.ClickLoginIconButton();
            Thread.Sleep(2000);
            kikaHomePage.loginModal.
                ClickLoginFormButton().
                IsLoginErrorMessageVisible().
                ClickLoginErrorMessageCloseButton().
                IsLoginErrorMessageNotVisible();

            Thread.Sleep(2000);
        }
    }
}
