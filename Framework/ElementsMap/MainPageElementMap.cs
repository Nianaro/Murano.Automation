using OpenQA.Selenium;

namespace Framework.ElementsMap
{
    public class MainPageElementMap : BasePageElementMap
    {
        public By CodeMirrorCode => By.ClassName("CodeMirror-code");
        public By FirstLineOfCodeMirrorCode => By.XPath("//*[@class='CodeMirror-code']/*[1]");
        public By Language => By.Id("Language");
    }
}