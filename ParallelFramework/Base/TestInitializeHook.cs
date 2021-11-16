﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using ParallelFramework.Config;
using ParallelFramework.Helpers;
using EdgeOptions = Microsoft.Edge.SeleniumTools.EdgeOptions;

namespace ParallelFramework.Base
{
    public class TestInitializeHook
    {
        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));

            LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    driverOptions = new InternetExplorerOptions();
                    break;
                case EdgeOptions edgeOptions:
                    //var edgeDriverService = Microsoft.Edge.SeleniumTools.EdgeDriverService.CreateChromiumService();
                    edgeOptions = new Microsoft.Edge.SeleniumTools.EdgeOptions();
                    edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    edgeOptions.UseChromium = true;
                    //_parallelConfig.Driver = new Microsoft.Edge.SeleniumTools.EdgeDriver(edgeDriverService, edgeOptions);
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\";
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalChromeOption(CapabilityType.EnableProfiling, true);
                    chromeOptions.AddAdditionalChromeOption(CapabilityType.BrowserName, "chrome");
                    break;
            }

            _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), driverOptions.ToCapabilities());
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