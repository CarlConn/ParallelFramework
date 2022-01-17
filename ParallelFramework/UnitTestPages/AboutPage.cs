using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using ParallelFramework.Base;
using ParallelFramework.Reports;
using SeleniumExtras.WaitHelpers;

namespace ParallelFramework.UnitTestPages
{
    public class AboutPage : BasePage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public AboutPage(IWebDriver Driver) : base(Driver) { }
        private IWebElement TxtAbout => Driver.FindElement(By.CssSelector("body > div.container.body-content > h2"));
        private IWebElement TxtSentence => Driver.FindElement(By.CssSelector("body > div.container.body-content > p"));

        private bool AboutPageIsPresent()
        {
            bool result = false;
            try
            {
                //Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for About Page");
                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class='container body-content']/h2")));
                //Reporter.LogTestStepForBugLogger(Status.Info, "About Page is present");
                result = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
                //Reporter.LogTestStepForBugLogger(Status.Fail, "About Page is not present");
            }

            return result;
        }

        public void AboutPageAssertPresent()
        {
            bool result = AboutPageIsPresent();
            try
            {
                Assert.IsTrue(result, "About Page is not present");
                //Reporter.LogPassingTestStepToBugLogger("About Page Assertion passed");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
                //Reporter.LogTestStepForBugLogger(Status.Fail, "About Page Assertion failed");
            }
        }

        public void AboutPageAssertHeaderText()
        {
            string expectedText = "About";
            string actualText = TxtAbout.Text;

            try
            {
                Assert.AreEqual(expectedText, actualText, "About Page Header text is not correct");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }

        }

        public void AboutPageAssertSentenceText()
        {
            string expectedText = "ExecuteAutomation Employee Application v1.0 is a simple web application for showing very few functionality of Employee details.";
            string actualText = TxtSentence.Text;

            try
            {
                Assert.AreEqual(expectedText, actualText, "About Page Header text is not correct");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
