using System;
using System.IO;
using Framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Framework.WebDriverSetUp
{
    public static class Driver
    {
        private static IWebDriver _browser;
        private static WebDriverWait _browserWait;

        public static IWebDriver Browser
        {
            get
            {
                if (_browser == null)
                    StartBrowser();
                return _browser;
            }
            private set => _browser = value;
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _browserWait;
            }
            private set => _browserWait = value;
        }

        public static void StartBrowser(SelectedBrowser selectedBrowserType = SelectedBrowser.Chrome, int defaultTimeOut = 120)
        {
            switch (selectedBrowserType)
            {
                case SelectedBrowser.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--start-maximized");
                    chromeOptions.AddArguments("--no-sandbox"); //didn't run via nunit3 console without this argument
                    Browser = new ChromeDriver(PathToDrivers(), chromeOptions);
                    Browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                    break;
                default:
                    throw new NotImplementedException("There is no implementation for this browser");
            }
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        public static void StopBrowser()
        {
            Browser.Quit();
            Browser = null;
        }

        public static string PathToDrivers()
        {
            return Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")), @"Framework\Drivers");
        }

        internal static IWebElement GetWebElementWhenDisplayed(By by)
        {
            BrowserWait.Until(browser => browser.FindElement(by).Displayed);
            return Browser.FindElement(by);
        }

        internal static bool WaitForStalenessOf(IWebElement element)
        {
            return BrowserWait.Until(ExpectedConditions.StalenessOf(element));
        }
    }
}