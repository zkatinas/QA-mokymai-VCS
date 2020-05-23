using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace QA_Mokymai_VCS_Pamoka_0409.Utils
{
    public class Waits
    {
        public static void WaitUntilModalBackgroundIsNotVisible()
        {
            try
            {
                Driver.TurnOffImplicitWait();
                new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(15)).Until(d => 
                {
                    try
                    {
                        Driver.Current.FindElement(By.CssSelector(".modal-backdrop.fade.in"));
                        return false;
                    }
                    catch (NoSuchElementException)
                    {
                        return true;
                    }
                } );
            }
            catch (WebDriverTimeoutException)
            {                
            }
            finally
            {
                Driver.TurnOnImplicitWait();
            } 
        }
    }
}
