using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumEasy.Pages;
using SeleniumEasy.Utilities;

namespace SeleniumEasy
{
    [Parallelizable]
    public class Tests
    {
        private HomePage homePage;
        private SearchResultPage searchResultPage;         

        [SetUp]
        public void BeforeTest()
        {
            Driver.InitializeDriver();
            Driver.CurrentDriver.Url = "https://www.sena.lt/";
            homePage = new HomePage();
            searchResultPage = new SearchResultPage();
        }

        [Test]
        public void SearchByTitleTest()
        {
            homePage.SearchByTitle("raktas");
            string expectedItemName = searchResultPage.GetItemTitle(1);
            Assert.IsTrue(expectedItemName.Contains("raktas", System.StringComparison.CurrentCultureIgnoreCase));
            string actualItemName = searchResultPage.ClickOnItem(1).
                GetItemName();
            Assert.AreEqual(expectedItemName.ToLower(), actualItemName.ToLower());
        }


        [TearDown]
        public void AfterTest()
        {
            ScreenshotMaker.MakeScreenshotOnTestFailure();
            Driver.CurrentDriver.Quit();
        }
    }
}