using OpenQA.Selenium;
using QA_Mokymai_Second_Project_SkyCop.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace QA_Mokymai_Second_Project_SkyCop.Pages
{
    public class FlightItineraryPage
    {
        private IWebElement elementDepartedFromInput => Driver.CurrentDriver.FindElement(By.CssSelector("#airport-departure input.Select-input"));
        private IWebElement elementDropDownOption => Driver.CurrentDriver.FindElement(By.CssSelector(".Select-menu-outer .Select-option"));
        private IWebElement elementDestinationmInput => Driver.CurrentDriver.FindElement(By.CssSelector("#airport-arrival input"));
        private IWebElement elementContinueButton => Driver.CurrentDriver.FindElement(By.CssSelector("#step-page-content #btn-step-continue"));


        public FlightItineraryPage EnterDepartedFrom(string inputDeparture)
        {
            elementDepartedFromInput.SendKeys(inputDeparture);
            elementDropDownOption.Click();
            return this;
        }

        public FlightItineraryPage EnterDestination(string inputDestination)
        {
            elementDestinationmInput.SendKeys(inputDestination);
            elementDropDownOption.Click();
            return this;
        }

        public DisruptionDetailsPage ClickContinueButton()
        {
            elementContinueButton.Click();
            return new DisruptionDetailsPage();
        }

    }
}
