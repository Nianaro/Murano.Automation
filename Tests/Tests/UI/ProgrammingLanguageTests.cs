using NUnit.Framework;
using static Framework.UI.Ui;
using Framework.Enums;

namespace Tests.Tests.UI
{
    public class ProgrammingLanguageTests : ImageBaseTestFixture
    {
        [Test]
        public void VerifyCSharpHelloWorldTest()
        {
            MainPage.Navigate();
            MainPage.SelectLanguage(Language.CSharp);
            TakeScreenshotCroppAndSave(MainPage.GetCodeMirrorCodeArea());
            Assert.IsTrue(CompareImages(), "Hello World for C# is not correct");
        }

        [Test]
        public void VerifyFSharpHelloWorldTest()
        {
            MainPage.Navigate();
            MainPage.SelectLanguageWithWaitCodeMirrorCodeUpdate(Language.FSharp);
            TakeScreenshotCroppAndSave(MainPage.GetCodeMirrorCodeArea());
            Assert.IsTrue(CompareImages(), "Hello World for F# is not correct");
        }

        [Test]
        public void VerifyVBNetHelloWorldTest()
        {
            MainPage.Navigate();
            MainPage.SelectLanguageWithWaitCodeMirrorCodeUpdate(Language.VbNet);
            TakeScreenshotCroppAndSave(MainPage.GetCodeMirrorCodeArea());
            Assert.IsTrue(CompareImages(), "Hello World for VB.Net is not correct");
        }
    }
}