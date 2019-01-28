using Framework.ElementsMap;
using Framework.WebDriverSetUp;

namespace Framework.Pages
{
    public abstract class BasePage<TMap> where TMap : BasePageElementMap, new() {
        protected readonly string Url;

        protected TMap Map = new TMap();

        protected BasePage(string url = null)
        {
            Url = url;
        }

        public void Navigate()
        {
            Driver.Browser.Navigate().GoToUrl(Url);
        }
    }
}