using System;
using System.Reflection;
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
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V96.DevToolsSessionDomains;

namespace ParallelFramework.Base
{
    [TestClass]
    public class TestInitialize
    {
        public RemoteWebDriver Driver { get; set; }
        protected IDevToolsSession session;
        protected DevToolsSessionDomains devToolsSession;

        [TestInitialize]
        public async Task InitializeSettings()
        {
            //Set all the settings for framework
            //Set teh browser




            ConfigReader.SetFrameworkSettings();

            //Open Browser
            await OpenBrowser(GetBrowserOption(Settings.BrowserType));
            //Set Log
            //LogHelpers.CreateLogFile();
            //LogHelpers.Write("Initialized framework");

        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Quit();
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
