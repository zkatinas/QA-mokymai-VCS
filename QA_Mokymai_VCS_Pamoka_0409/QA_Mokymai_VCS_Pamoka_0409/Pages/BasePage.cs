using OpenQA.Selenium;
using QA_Mokymai_VCS_Pamoka_0409.Utils;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public KikaHeaderSection Header => new KikaHeaderSection();

        protected BasePage()
        {
            driver = Driver.Current;
        }
    }
}
