using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Framework.Helpers;
using NUnit.Framework;

namespace Tests.Tests.UI
{
    public class ImageBaseTestFixture : BaseTestFixture
    {
        private int _screenWidth;
        private int _screenHeight;

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            _screenWidth = Screen.PrimaryScreen.Bounds.Width;
            _screenHeight = Screen.PrimaryScreen.Bounds.Height;

            new CResolution(1600, 900);

        }

        [OneTimeTearDown]
        public override void OneTimeTearDown()
        {
            base.OneTimeTearDown();
            new CResolution(_screenWidth, _screenHeight);
        }


        public void TakeScreenshotCroppAndSave(Rectangle croppArea)
        {
            ImageHelper.TakeScreenshotCroppAndSave
                        (
                            TestContext.CurrentContext.Test.ClassName.Split('.').Last(),
                            TestContext.CurrentContext.Test.MethodName,
                            croppArea
                        );
        }

        public bool CompareImages()
        {
            return ImageHelper.CompareImages
                                (
                                    TestContext.CurrentContext.Test.ClassName.Split('.').Last(),
                                    TestContext.CurrentContext.Test.MethodName
                                );
        }
    }
}