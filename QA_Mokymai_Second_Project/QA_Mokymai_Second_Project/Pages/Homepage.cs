using OpenQA.Selenium;
using QA_Mokymai_Second_Project_SkyCop.Utilities;


namespace QA_Mokymai_Second_Project_SkyCop.Pages
{
    public class Homepage
    {       
        
        private IWebElement elementClaimSubmitButton => Driver.CurrentDriver.FindElement(By.CssSelector(".hero-form .hero"));       


        public FlightItineraryPage ClickClaimButton()
        {
            elementClaimSubmitButton.Click();
            return new FlightItineraryPage();
        }
        

        
    }
}
