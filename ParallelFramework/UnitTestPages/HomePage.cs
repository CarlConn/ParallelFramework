using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Debugger;
using OpenQA.Selenium.Support.UI;
using ParallelFramework;
using ParallelFramework.Base;
using ParallelFramework.Reports;
using SeleniumExtras.WaitHelpers;

namespace ParallelFramework.UnitTestPages
{
    public class HomePage : BasePage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public HomePage(IWebDriver Driver) : base(Driver) { }

        private IWebElement BtnLearnMore => Driver.FindElement(By.XPath(".//div[@class='col-md-4']/p[2]/a"));

        private bool HomePageIsPresent()
        {
            bool result = false;
            try
            {
                Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Home Page to be present");
                Wait.Until(ExpectedConditions.ElementToBeClickable(BtnLearnMore));
                Reporter.LogTestStepForBugLogger(Status.Info, "Home Page is present");
                result = true;
            }
            catch (TimeoutException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Home Page is not present. {e.Message}");
            }

            return result;
        }

        public void HomePageAssertPresent()
        {
            bool result = HomePageIsPresent();
            try
            {
                Assert.IsTrue(result, "Home Page is not present");
                Reporter.LogPassingTestStepToBugLogger("Home Page Assertion passed");
            }
            catch (AssertFailedException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Home Page Present Assertion failed");
            }
        }
    }
}
