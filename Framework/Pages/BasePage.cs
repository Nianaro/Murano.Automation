using Framework.WebDriverSetUp;

namespace Framework.Pages
{
    public abstract class BasePage<M> where M : new()
    {
        protected readonly string Url;

        protected M Map = new M();

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