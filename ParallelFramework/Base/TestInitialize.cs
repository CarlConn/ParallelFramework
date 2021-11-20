using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using ParallelFramework.Config;
using ParallelFramework.Helpers;
using EdgeOptions = Microsoft.Edge.SeleniumTools.EdgeOptions;

namespace ParallelFramework.Base
{
    public class TestInitialize
    {
        // private readonly ParallelConfig _parallelConfig;
        // public TestInitialize(ParallelConfig parallelConfig)
        // {
        //     _parallelConfig = parallelConfig;
        // }

        public RemoteWebDriver Driver { get; set; }

        public void InitializeSettings()
        {
            //Set all the settings for framework
            //Set teh browser
            ConfigReader.SetFrameworkSettings();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));

            //Set Log
            //LogHelpers.CreateLogFile();
            //LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(DriverOptions driverOptions)
        {
            var outPutDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    driverOptions = new InternetExplorerOptions();
                    break;
                case EdgeOptions edgeOptions:
                    edgeOptions = new Microsoft.Edge.SeleniumTools.EdgeOptions();
                    edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    edgeOptions.UseChromium = true;
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalOption(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalOption(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\";
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalChromeOption(CapabilityType.EnableProfiling, true);
                    chromeOptions.AddAdditionalChromeOption(CapabilityType.BrowserName, "chrome");
                    break;
            }

            //_parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), driverOptions.ToCapabilities());
            Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), driverOptions.ToCapabilities());
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
    }
}
