using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    [Parallelizable]
    public class LoginBadUserKika : BaseTest
    {

        [Test]
        public void TestLoginEmpty()
        {
            Thread.Sleep(2000);
            popUpModal.ClosePopUpModal();
            Thread.Sleep(2000);
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
