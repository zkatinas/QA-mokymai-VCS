using OpenQA.Selenium;

namespace QA_Mokymai_VCS_Pamoka_0409.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
