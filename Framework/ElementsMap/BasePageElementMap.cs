using Framework.WebDriverSetUp;
using OpenQA.Selenium;

namespace Framework.ElementsMap
{
    public class BasePageElementMap
    {
        protected IWebDriver Browser;

        public BasePageElementMap()
        {
            Browser = Driver.Browser;
        }
    }
}