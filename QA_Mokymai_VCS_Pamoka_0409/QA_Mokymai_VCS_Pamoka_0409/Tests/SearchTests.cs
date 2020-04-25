using NUnit.Framework;
using QA_Mokymai_VCS_Pamoka_0409.Utils;


namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    public class SearchTests : BaseTest
    {
        [SetUp]
        public void Before()
        {           
            kikaHomePage.Login(User.DefaultKikaUser);
        }

        [Test]
        public void TestSearchWorks()
        {
            var searchInput = "canin";
            kikaHomePage.header
                .ClickOnSearchIcon()
                .Search(searchInput).
                AssertSearchResultsContainsText(searchInput);           
        }


    }
}
