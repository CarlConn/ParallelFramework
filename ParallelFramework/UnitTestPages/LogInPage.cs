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
using ParallelFramework.UnitTests;
using SeleniumExtras.WaitHelpers;

namespace ParallelFramework.UnitTestPages
{
    public class LogInPage : BasePage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public LogInPage(IWebDriver Driver) : base(Driver) { }
        private IWebElement TxtUserName => Driver.FindElement(By.XPath(".//div[@class='col-md-10']/input"));
        private IWebElement TxtPassWord => Driver.FindElement(By.XPath("//*[@id='Password']"));
        private IWebElement BtnLogIn => Driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[4]/div/input"));

        private IWebElement LnkInvalidLogIn =>
            Driver.FindElement(By.XPath(".//div[@class='validation-summary-errors text-danger']/ul/li"));

        private bool LogInPageIsPresent()
        {
            bool result = false;
            try
            {
                Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Log In Page to be present");
                Wait.Until(ExpectedConditions.ElementToBeClickable(BtnLogIn));
                Reporter.LogTestStepForBugLogger(Status.Info, "Log In Page is present");
                result = true;
            }
            catch (NoSuchElementException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Log In Page is not present. {e.Message}");
            }

            return result;
        }

        public void LogInPagAssertPresent()
        {
            bool result = LogInPageIsPresent();
            try
            {
                Assert.IsTrue(result, "Log In Page is not present");
                Reporter.LogPassingTestStepToBugLogger("Long In page Assertion Passed");
            }
            catch (AssertFailedException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Log In Page is not present. {e.Message}");
            }
        }

        public void LogInPageEnterUserName(string userName)
        {
            Reporter.LogTestStepForBugLogger(Status.Info, $"Log In Page User Name is {userName}");
            TxtUserName.SendKeys(userName);
        }

        public void LogInPageEnterPassWord(string passWord)
        {
            Reporter.LogTestStepForBugLogger(Status.Info, $"Log In Page entered Password {passWord}");
            TxtPassWord.SendKeys(passWord);
        }

        public HomePage LogInPagePressLogIn()
        {
            BtnLogIn.Click();
            Reporter.LogTestStepForBugLogger(Status.Info, "Log In Page Pressed Log In button");
            return new HomePage(Driver);
        }

        public bool LogInPageIsInvalidPresent()
        {
            bool result = false;
            try
            {
                Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Log In Page Invalid text");
                Wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath(".//div[@class='validation-summary-errors text-danger']/ul/li")));
                Reporter.LogTestStepForBugLogger(Status.Info, "Log In Page Invalid text is present");
                result = true;
            }
            catch (TimeoutException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Log In Page Invalid text is not present. {e.Message} ");
            }

            return result;
        }

        public void LogInPageAssertInvalidPresent()
        {
            bool result = LogInPageIsInvalidPresent();
            try
            {
                Assert.IsTrue(result, "Log In Page Invalid is not present");
                Reporter.LogPassingTestStepToBugLogger("Log In Page Invalid Assertion Passed");
            }
            catch (AssertFailedException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Info, $"Log In Page Invalid text Assertion Failed");
            }
        }
    }

}