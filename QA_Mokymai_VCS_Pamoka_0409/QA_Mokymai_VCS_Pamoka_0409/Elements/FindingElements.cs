using NUnit.Framework;
using OpenQA.Selenium;
using QA_Mokymai_VCS_Pamoka_0409.Utils;


namespace QA_Mokymai_VCS_Pamoka_0409.Elements
{
    public class FindingElements
    {

        [Test]
        public void FindElementsTests()
        {
            Driver.Init();
            var d = Driver.Current.FindElement(By.CssSelector(""));
            var s = d.TagName;
        }
    }
}
