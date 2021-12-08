﻿using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using ParallelFramework.Config;
using ParallelFramework.Helpers;

namespace ParallelFramework.Base
{
    [TestClass]
    public class TestInitialize
    {
        // private readonly ParallelConfig _parallelConfig;
        // public TestInitialize(ParallelConfig parallelConfig)
        // {
        //     _parallelConfig = parallelConfig;
        // }

        public RemoteWebDriver Driver { get; set; }

        
        [TestInitialize]
        public void InitializeSettings()
        {
            //Set all the settings for framework
            //Set teh browser
            
            
            
            
            ConfigReader.SetFrameworkSettings();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));
            Driver.Manage().Window.Maximize();
            //Set Log
            //LogHelpers.CreateLogFile();
            //LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(DriverOptions driverOptions)
        {
            var outPutDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", outPutDirectory);
            switch (driverOptions)
            {
                case InternetExplorerOptions:
                    driverOptions = new InternetExplorerOptions();
                    break;
                case EdgeOptions:
                    driverOptions = new EdgeOptions();
                    driverOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    break;
                case FirefoxOptions:
                    driverOptions = new FirefoxOptions();
                    driverOptions.AddAdditionalOption(CapabilityType.BrowserName, "firefox");
                    driverOptions.AddAdditionalOption(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    break;
                case ChromeOptions:
                    driverOptions = new ChromeOptions();
                    driverOptions.PlatformName = "windows";
                    break;
            }

            Driver = new RemoteWebDriver(new Uri("http://localhost:4444"), driverOptions);
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
