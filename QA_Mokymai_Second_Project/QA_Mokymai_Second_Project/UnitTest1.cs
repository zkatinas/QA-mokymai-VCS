using NUnit.Framework;
using QA_Mokymai_Second_Project_SkyCop.Pages;
using QA_Mokymai_Second_Project_SkyCop.Utilities;

namespace QA_Mokymai_Second_Project_SkyCop
{
    public class Tests
    {
        public Homepage homePage;

        [SetUp]
        public void Setup()
        {
            Driver.InitiliazeDriver();
            homePage = new Homepage();
            Driver.CurrentDriver.Url = "https://www.skycop.com/";
        }

        [Test]
        public void CompleteFlightItineraryInfo()
        {
            homePage.ClickClaimButton().
                EnterDepartedFrom("viln").
                EnterDestination("kaun").
                ClickContinueButton().
                VerifyPageTitle();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.CurrentDriver.Quit();
        }
    }
}