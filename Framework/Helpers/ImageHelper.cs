using System;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using static Framework.WebDriverSetUp.Driver;
using static Framework.Helpers.DirectoriesAndFiles;

namespace Framework.Helpers
{
    public static class ImageHelper
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private const string Up = @"..\..\..\";
        private const string Diffs = "Diffs";
        private const string ActualPng = "Actual.png";
        private const string ExpectedPng = "Expected.png";
        private const string DiffPng = "Diff.png";

        public static void TakeScreenshotCroppAndSave(string className, string methodName, Rectangle croppArea)
        {
            var screenshot = ((ITakesScreenshot)Browser).GetScreenshot();

            var cropped = Cropp(screenshot, croppArea);

            var directory = Path.GetFullPath
            (
                Path.Combine
                (
                    BaseDirectory,
                    Up,
                    Diffs,
                    className,
                    methodName
                )
            );

            CreateDirectoriesIfMissing(directory);

            cropped.Save
            (
                Path.Combine
                (
                    directory,
                    ActualPng
                )
            );
        }

        public static bool CompareImages(string className, string methodName)
        {
            var directory = Path.GetFullPath
            (
                Path.Combine
                (
                    BaseDirectory,
                    Up,
                    Diffs,
                    className,
                    methodName
                )
            );

            var pathToActualImage = Path.Combine(directory, ActualPng);
            var pathToExpectedImage = Path.Combine(directory, ExpectedPng);
            var pathToDiffImage = Path.Combine(directory, DiffPng);

            var firstImage = new Bitmap(pathToActualImage);
            var secondImage = new Bitmap(pathToExpectedImage);

            // Make a difference image.
            var width = Math.Min(firstImage.Width, secondImage.Width);
            var height = Math.Min(firstImage.Height, secondImage.Height);
            var diffImage = new Bitmap(width, height);

            //Create the difference image
            var areIdentical = true;
            var equalColor = Color.White;
            var diffColor = Color.Red;
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (firstImage.GetPixel(x, y).Equals(secondImage.GetPixel(x, y)))
                        diffImage.SetPixel(x, y, equalColor);
                    else
                    {
                        diffImage.SetPixel(x, y, diffColor);
                        areIdentical = false;
                    }
                }
            }

            if ((firstImage.Width != secondImage.Width) || (firstImage.Height != secondImage.Height))
                areIdentical = false;

            if (areIdentical)
                return true;

            diffImage.Save(pathToDiffImage);
            return false;
        }

        private static Bitmap Cropp(Screenshot screenshot, Rectangle croppArea)
        {
            MemoryStream memoryStream = null;
            Bitmap bitmapOfScreenshot = null;
            try
            {
                memoryStream = new MemoryStream(screenshot.AsByteArray);
                bitmapOfScreenshot = new Bitmap(memoryStream);
                return bitmapOfScreenshot.Clone(croppArea, bitmapOfScreenshot.PixelFormat);
            }
            finally
            {
                memoryStream?.Dispose();
                bitmapOfScreenshot?.Dispose();
            }
        }
    }
}