using Framework.ElementsMap;
using Framework.Entities;
using static Framework.WebDriverSetUp.Driver;
using Framework.Enums;
using OpenQA.Selenium.Support.UI;
using System.Drawing;

namespace Framework.Pages
{
    public class MainPage : BasePage<MainPageElementMap> {
        private const string Value = "value";

        public MainPage() : base(URL.Host) {}

        public Rectangle GetCodeMirrorCodeArea()
        {
            var element = GetWebElementWhenDisplayed(Map.CodeMirrorCode);
            return new Rectangle(element.Location.X, element.Location.Y,
                                element.Size.Width, element.Size.Height);
        }

        public void SelectLanguage(Language language)
        {
            var select = new SelectElement(GetWebElementWhenDisplayed(base.Map.Language));
            if (select.SelectedOption.GetAttribute(Value).Equals(language.ToString()))
                return;
            select.SelectByValue(language.ToString());
        }

        public void SelectLanguageWithWaitCodeMirrorCodeUpdate(Language language)
        {
            var select = new SelectElement(GetWebElementWhenDisplayed(base.Map.Language));
            if (select.SelectedOption.GetAttribute(Value).Equals(language.ToString()))
                return;
            var firstLineOfCodeMirrorCode = GetWebElementWhenDisplayed(base.Map.FirstLineOfCodeMirrorCode);
            select.SelectByValue(language.ToString());
            WaitForStalenessOf(firstLineOfCodeMirrorCode);
        }
    }
}