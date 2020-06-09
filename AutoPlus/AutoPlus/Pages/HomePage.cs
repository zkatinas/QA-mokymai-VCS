using AutoPlus.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPlus.Pages
{
    public class HomePage
    {
        private IWebElement elementMake => Driver.CurrentDriver.FindElement(By.CssSelector(".js-make"));
        private IWebElement elementSearchButton => Driver.CurrentDriver.FindElement(By.CssSelector(".quick-search-form [type='submit']"));
        
        private IWebElement DropdownElement(string title)
        {
            return Driver.CurrentDriver.FindElement(By.CssSelector($".js-dropdown.show .js-option[data-title='{title}']"));
        }

        public HomePage SelectMakeFromDropdown(string carMake)
        {
            ClickMake();
            DropdownElement(carMake).Click();
            return this;
        }

        public HomePage SelectModelFromDropdown(string carModel)
        {
            DropdownElement(carModel).Click();
            return this;
        }

        public HomePage ClickMake()
        {
            elementMake.Click();
            return this;
        }

        public HomePage ClickSearch()
        {
            elementSearchButton.Click();
            return this;
        }
    }
}
