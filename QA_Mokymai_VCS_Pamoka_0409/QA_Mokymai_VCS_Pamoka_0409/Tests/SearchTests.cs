using NUnit.Allure.Core;
using NUnit.Framework;
using QA_Mokymai_VCS_Pamoka_0409.Utils;


namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    [AllureNUnit]
    [Parallelizable]
    public class SearchTests : BaseTest
    {
        [SetUp]
        public void Before()
        {
            popUpModal.ClosePopUpModal();
            kikaHomePage.Login(User.DefaultKikaUser);
        }

        [Test]
        public void TestSearchWorks()
        {
            var searchInput = "canin";
            kikaHomePage.Header
                .ClickOnSearchIcon()
                .Search(searchInput).
                AssertSearchResultsContainsText(searchInput);           
        }


    }
}
