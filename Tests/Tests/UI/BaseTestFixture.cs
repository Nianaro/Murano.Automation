using NUnit.Framework;
using Framework.WebDriverSetUp;
using Microsoft.Expression.Encoder.ScreenCapture;
using System.IO;
using System;
using System.Linq;

namespace Tests.Tests.UI
{
    [TestFixture]
    public class BaseTestFixture
    {

        private ScreenCaptureJob scj;

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            var f = Path.GetFullPath
                            (
                                Path.Combine
                                (
                                    AppDomain.CurrentDomain.BaseDirectory,
                                    @"..\..\..\",
                                    "Records"
                                )
                            );
            if (Directory.Exists(f))
                Directory.Delete(f, true);
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {

        }

        [SetUp]
        public virtual void SetUp()
        {
            Driver.StartBrowser();
            scj = new ScreenCaptureJob
            {
                OutputScreenCaptureFileName = Path.Combine
                            (
                                Path.GetFullPath
                                (
                                    Path.Combine
                                    (
                                        AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"
                                    )
                                ),
                                "Records",
                                TestContext.CurrentContext.Test.ClassName.Split('.').Last(),
                                $"{TestContext.CurrentContext.Test.MethodName}.avi"
                            )
            };
            scj.Start();
        }

        [TearDown]
        public virtual void TearDown()
        {
            scj.Stop();
            scj = null;
            Driver.StopBrowser();
        }
    }
}