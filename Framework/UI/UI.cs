using Framework.Pages;
using Framework.ElementsMap;

namespace Framework.UI
{
    public static class Ui
    {
        private static MainPage<MainPageElementMap> _mainPage;
        public static MainPage<MainPageElementMap> MainPage =>
            _mainPage ?? (_mainPage = new MainPage<MainPageElementMap>());
    }
}