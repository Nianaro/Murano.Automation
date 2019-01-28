using Framework.Pages;

namespace Framework.UI
{
    public static class Ui
    {
        private static MainPage _mainPage;
        public static MainPage MainPage =>
            _mainPage ?? (_mainPage = new MainPage());
    }
}