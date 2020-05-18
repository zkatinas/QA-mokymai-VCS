using NUnit.Framework;
using QA_Mokymai_Second_Project_SkyCop.Pages;
using QA_Mokymai_Second_Project_SkyCop.Utilities;


namespace QA_Mokymai_Second_Project_SkyCop
{
    [Parallelizable]
    public class UnitTest2
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
        public void CompleteFlightItineraryInfo2()
        {
            homePage.ClickClaimButton().
                EnterDepartedFrom("kaun").
                EnterDestination("viln").
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
