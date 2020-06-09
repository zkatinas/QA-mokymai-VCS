using AutoPlus.Pages;
using AutoPlus.Utilities;
using NUnit.Framework;
using System;

namespace AutoPlus
{
    public class Tests
    {
        HomePage homePage;
        SearchResultsPage searchResultsPage;
        
        [SetUp]
        public void Setup()
        {
            Driver.InitializeDriver();
            Driver.CurrentDriver.Url = "https://autoplius.lt/";
            homePage = new HomePage();
            searchResultsPage = new SearchResultsPage();
        }

        [Test]
        public void Test1()
        {
            var carMake = CarMakes.Audi;
            var carModel = AudiModels.SQ7;
            homePage
                .SelectMakeFromDropdown(carMake)
                .SelectModelFromDropdown(carModel)
                .ClickSearch();
            Assert.IsTrue(searchResultsPage.GetProductName().Contains(carMake, StringComparison.CurrentCultureIgnoreCase), $"It is not {carMake}.");
            Assert.IsTrue(searchResultsPage.GetProductName().Contains(carModel, StringComparison.CurrentCultureIgnoreCase), $"It is not {carModel}.");
        }

        [TearDown]
        public void Quit()
        {
            Driver.CurrentDriver.Quit();
        }
    }
}