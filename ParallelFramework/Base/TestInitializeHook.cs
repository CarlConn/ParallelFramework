using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using ParallelFramework.Config;
using ParallelFramework.Helpers;

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
            OpenBrowser(Settings.BrowserType);

            LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(BrowserType browserType = BrowserType.FireFox)
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            switch (browserType)
            {
                case BrowserType.Edge:
                    var options = new EdgeOptions();
                    options.UseChromium = true;
                    
                    var driver = new EdgeDriver(options);
                    _parallelConfig.Driver = new EdgeDriver();
                    break;
                case BrowserType.FireFox:
                    cap.SetCapability(CapabilityType.BrowserName, "firefox");
                    cap.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                    var profile = new FirefoxProfile();
                    break;
                case BrowserType.Chrome:
                    cap.SetCapability(CapabilityType.BrowserName, "chrome");
                    break;
            }

            _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), cap);

        }
    }
}
