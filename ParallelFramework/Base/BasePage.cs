using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ParallelFramework.Base
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            WebDriverWait wait = new WebDriverWait(Driver, timeout: TimeSpan.FromSeconds(40))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Wait = wait;
        }
        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; set; }
    }
}
