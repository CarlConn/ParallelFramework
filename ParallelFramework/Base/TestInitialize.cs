using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.DevTools;
using ParallelFramework.Config;
using ParallelFramework.Helpers;
using OpenQA.Selenium.DevTools.V96.Emulation;
using ParallelFramework.Reports;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V96.DevToolsSessionDomains;
using NLog;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ParallelFramework.Base
{
    [TestClass]
    public class TestInitialize
    {
        public RemoteWebDriver Driver { get; set; }
        protected IDevToolsSession session;
        protected DevToolsSessionDomains devToolsSession;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static TestContext _testContext;
        public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext { get; set; }
        private ScreenShotTaker ScreenShotTaker { get; set; }

        [TestInitialize]
        public async Task InitializeSettings()
        {
            Logger.Debug("*************************************** TEST STARTED");
            Logger.Debug("*************************************** TEST STARTED");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            ConfigReader.SetFrameworkSettings();
            await OpenBrowser(GetBrowserOption(Settings.BrowserType));
            ScreenShotTaker = new ScreenShotTaker(Driver, TestContext);
            var outPutDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Driver.Navigate().GoToUrl(outPutDirectory + @"\construction.html");

        }

        [TestCleanup]
        public void CleanUp()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (System.Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext);
                Logger.Debug("*************************************** TEST STOPPED");
                Logger.Debug("*************************************** TEST STOPPED");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenShotTaker != null)
            {
                ScreenShotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenShotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }

        public void EnterZipForCookie()
        {

            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, timeout: TimeSpan.FromSeconds(3))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(500),
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                var zip = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("zipcodeInput")));
                if (zip != null)
                {
                    zip.SendKeys("98007");
                    Driver.FindElement(By.Id("zipcodeSubmit")).Click();
                }

            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                WebDriverWait wait = new WebDriverWait(Driver, timeout: TimeSpan.FromSeconds(45));
                //eat this error... object not there.
            }
        }



        private async Task OpenBrowser(DriverOptions driverOptions)
        {
            //var outPutDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", outPutDirectory);
            switch (driverOptions)
            {
                case InternetExplorerOptions:
                    driverOptions = new InternetExplorerOptions();
                    break;
                case EdgeOptions:
                    driverOptions = new EdgeOptions();
                    Driver = new RemoteWebDriver(new Uri("http://localhost:4444"), driverOptions.ToCapabilities());
                    await DeviceModeTest(Settings.BrowserSize);
                    break;
                case FirefoxOptions:
                    driverOptions = new FirefoxOptions();
                    //driverOptions.AddAdditionalOption(CapabilityType.BrowserName, "firefox");
                    //driverOptions.AddAdditionalOption(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    Driver = new RemoteWebDriver(new Uri("http://localhost:4444"), driverOptions.ToCapabilities());
                    await DeviceModeTest(Settings.BrowserSize);
                    break;
                case ChromeOptions:
                    driverOptions = new ChromeOptions();
                    Driver = new RemoteWebDriver(new Uri("http://localhost:4444"), driverOptions.ToCapabilities());
                    await DeviceModeTest(Settings.BrowserSize);
                    break;
            }

            //Driver = new RemoteWebDriver(new Uri("http://localhost:4444"), driverOptions.ToCapabilities());
            //await DeviceModeTest(BrowserSize.Maximized);
        }

        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Edge:
                    return new EdgeOptions();
                case BrowserType.InternetExplorer:
                    return new InternetExplorerOptions();
                case BrowserType.FireFox:
                    return new FirefoxOptions();
                case BrowserType.Chrome:
                    return new ChromeOptions();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }

        public async Task DeviceModeTest(BrowserSize browserSize)
        {
            //new DriverManager().SetUpDriver(new ChromeConfig());
            //ChromeOptions chromeOptions = new ChromeOptions();
            //Set ChromeDriver
            //Driver = new ChromeDriver();
            //Get DevTools
            IDevTools devTools = Driver as IDevTools;
            //DevTools Session
            session = devTools.GetDevToolsSession();

            var deviceModeSetting = new SetDeviceMetricsOverrideCommandSettings();
            switch (browserSize)
            {
                case BrowserSize.Maximized:
                    Driver.Manage().Window.Maximize();
                    break;
                case BrowserSize.RestoredDown:
                    //deviceModeSetting.Width = 375;
                    //deviceModeSetting.Height = 667;
                    deviceModeSetting.Mobile = false;
                    deviceModeSetting.DeviceScaleFactor = 100;
                    break;
                case BrowserSize.iPhone:
                    deviceModeSetting.Width = 375;
                    deviceModeSetting.Height = 667;
                    deviceModeSetting.Mobile = true;
                    deviceModeSetting.DeviceScaleFactor = 100;
                    break;
                case BrowserSize.iPad:
                    deviceModeSetting.Width = 768;
                    deviceModeSetting.Height = 1024;
                    deviceModeSetting.Mobile = true;
                    deviceModeSetting.DeviceScaleFactor = 100;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserSize), browserSize, null);
            }

            /*
            var deviceModeSetting = new SetDeviceMetricsOverrideCommandSettings();
            deviceModeSetting.Width = 375;
            deviceModeSetting.Height = 667;
            deviceModeSetting.Mobile = true;
            deviceModeSetting.DeviceScaleFactor = 100;
            */
            await session
                .GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V96.DevToolsSessionDomains>()
                .Emulation
                .SetDeviceMetricsOverride(deviceModeSetting);
        }
    }
}
