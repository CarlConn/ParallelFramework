using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson.IO;
using NLog;
using OpenQA.Selenium;
using ParallelFramework.Base;
using ParallelFramework.Config;
using ParallelFramework.Reports;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace ParallelFramework.UnitTestPages
{
    public class BannerPage : BasePage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public BannerPage(IWebDriver Driver) : base(Driver) { }
        private IWebElement LnkHome => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[1]/a"));
        private IWebElement LnkAbout => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[2]/a"));
        private IWebElement LnkEmployeeList => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[3]/a"));
        private IWebElement LnkRegister => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[2]/li[1]/a"));
        private IWebElement LnkLogIn => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[2]/li[2]/a"));
        private IWebElement LnkHamburger =>
            Driver.FindElement(By.XPath(".//button[@type='button' and @class='navbar-toggle']"));
        private IWebElement LnkHamburgerHome => Driver.FindElement(By.XPath(".//ul[@class='nav navbar-nav']/li[1]/a"));
        private IWebElement LnkHamburgerAbout => Driver.FindElement(By.XPath(".//ul[@class='nav navbar-nav']/li[2]/a"));
        private IWebElement LnkHamburgerEmployeeList => Driver.FindElement(By.XPath(".//ul[@class='nav navbar-nav']/li[3]/a"));
        private IWebElement LnkHamburgerHello =>
            Driver.FindElement(By.XPath(".//ul[@class='nav navbar-nav navbar-right']/li[1]/a"));
        private IWebElement LnkHamburgerLogOff =>
            Driver.FindElement(By.XPath(".//ul[@class='nav navbar-nav navbar-right']/li[2]/a"));
        private IWebElement LnkHamburgerRegister => Driver.FindElement(By.Id("registerLink"));
        private IWebElement LnkHamburgerLogIn => Driver.FindElement(By.Id("loginLink"));
        private IWebElement LnkLogOut =>
            Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/form/ul/li[2]/a"));
        private IWebElement LnkHello =>
            Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/form/ul[1]/li/a"));

        private bool BannerPageIsPresent()
        {
            bool result = false;
            try
            {
                if (LnkHamburger.Displayed)
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Wating for Banner Page");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburger));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page is present");
                }
                else
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Wating for Banner Page");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkAbout));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page is present");

                }

                result = true;
            }
            catch (TimeoutException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Banner Page is not present. {e.Message}");
            }

            return result;
        }

        public void BannerPageAssertPresent()
        {
            bool result = BannerPageIsPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page is not present");
                Reporter.LogPassingTestStepToBugLogger("Banner Page Assertion passed");
            }
            catch (AssertFailedException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Banner Page Assertion failed. {e.Message}");
            }
        }

        private bool BannerPageIsHomeLinkPresent()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHome));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        private bool BannerPageIsAboutLinkPresent()
        {
            bool result = false;
            try
            {
                if (LnkHamburger.Displayed)
                {
                    LnkHamburger.Click();
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page waiting for Hamburger About");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerAbout));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page Hamburger About is present");
                }
                else
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page About link");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkAbout));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page About link is present");
                }
                result = true;

            }
            catch (TimeoutException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Banner Page About link not present. {e.Message}");
            }

            return result;
        }

        private bool BannerPageIsEmployeeListLinkPresent()
        {
            bool result = false;
            try
            {
                if (LnkHamburger.Displayed)
                {
                    LnkHamburger.Click();
                    Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Hamburger Employee List");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerEmployeeList));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page Hamburger Employee List is present");
                }
                else
                {
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkAbout));
                }
                result = true;
            }
            catch (TimeoutException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Banner Page Hamburger Employee List link is not present");
            }

            return result;
        }

        private bool BannerPageIsHelloLinkPresent()
        {
            bool result = false;
            try
            {
                if (LnkHamburger.Displayed)
                {
                    LnkHamburger.Click();
                    Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Banner Page Hello link");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerHello));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page Hello link is present");
                }
                else
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Banner Page Hello link");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHello));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page Hello Link is present");
                }
                result = true;
            }
            catch (TimeoutException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Banner Page Hello Link is not present. {e.Message}");
            }

            return result;
        }

        private bool BannerPageIsLogOffLinkPresent()
        {
            bool result = false;
            try
            {
                if (LnkHamburger.Displayed)
                {
                    LnkHamburger.Click();
                    Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Banner Page Log Off link");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerLogOff));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page Log Off link is present");
                }
                else
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Banner Page About link");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkAbout));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page About link is present");
                }
                result = true;
            }
            catch (TimeoutException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Banner Page Log Off link not present. {e.Message}");
            }

            return result;
        }

        private bool BannerPageIsRegisterLinkPresent()
        {
            bool result = false;
            try
            {
                if (LnkHamburger.Displayed)
                {
                    LnkHamburger.Click();
                    Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Banner Page Hamburger Register link");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerRegister));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page Hamburger Register link is present");
                }
                else
                {
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkRegister));
                }
                result = true;
            }
            catch (TimeZoneNotFoundException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Banner Page Hamburger Registerr link is not present. {e.Message}");
            }

            return result;
        }

        private bool BannerPageIsLogInLinkPresent()
        {
            bool result = false;
            try
            {
                if (LnkHamburger.Displayed)
                {
                    LnkHamburger.Click();
                    Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Banner Page Hamburger Log In link");
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerLogIn));
                    Reporter.LogTestStepForBugLogger(Status.Info, "Banner Page Hamburger Log In link is present");
                }
                else
                {
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkLogIn));
                }
                result = true;
            }
            catch (TimeZoneNotFoundException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Banner Page Hamburger Link is not present. {e.Message}");
            }

            return result;
        }

        public void BannerPageAssertHomeLinkPresent()
        {
            bool result = BannerPageIsAboutLinkPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page Home Button is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }
        }

        public void BannerPageAssertAboutLinkPresent()
        {
            bool result = BannerPageIsAboutLinkPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page About Button is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }
        }

        public void BannerPageAssertEmployeeListLinkPresent()
        {
            bool result = BannerPageIsEmployeeListLinkPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page Employee List Link is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }
        }

        public void BannerPageAssertRegisterLinkPresent()
        {
            bool result = BannerPageIsRegisterLinkPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page Register Link is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }
        }

        public void BannerPageAssertHelloLinkPresent()
        {
            bool result = BannerPageIsHelloLinkPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page Hello Link is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void BannerPageAssertLogOffLinkPresent()
        {
            bool result = BannerPageIsLogOffLinkPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page Log Off Link is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void BannerPageAssertLogInLinkPresent()
        {
            bool result = BannerPageIsLogInLinkPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page Log In Link is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public AboutPage BannerPagePressAboutPageLink()
        {
            if (LnkHamburger.Displayed)
            {
                LnkHamburger.Click();
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerAbout)).Click();
            }
            else
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkAbout)).Click();
            }
            return new AboutPage(Driver);
        }

        public EmployeeListPage BannerPageClickEmployeeListLink()
        {
            if (LnkHamburger.Displayed)
            {
                LnkHamburger.Click();
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerEmployeeList)).Click();
            }
            else
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkEmployeeList)).Click();
            }
            return new EmployeeListPage(Driver);
        }

        public LogInPage BannerPageClickLogInLink()
        {
            if (LnkHamburger.Displayed)
            {
                LnkHamburger.Click();
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerLogIn)).Click();
            }
            else
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkLogIn)).Click();
            }
            return new LogInPage(Driver);
        }

        public void BannerPageAssertLoggedIn()
        {
            string expectedText = "Hello" + " " + Settings.UserName + "!";
            string actualText = null;

            if (LnkHamburger.Displayed)
            {
                LnkHamburger.Click();
                actualText = LnkHamburgerHello.Text;
            }
            else
            {
                actualText = LnkHello.Text;
            }

            try
            {
                Assert.AreEqual(expectedText, actualText, "The member is not Logged In");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void BannerPageAssertSignedOut()
        {
            bool result = BannerPageIsRegisterLinkPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page Register link is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }
        }

        public void BannerPagePressLogOutLink()
        {
            try
            {
                if (LnkHamburger.Displayed)
                {
                    LnkHamburger.Click();
                    Wait.Until(ExpectedConditions.ElementToBeClickable(LnkHamburgerLogOff)).Click();
                }
                else
                {
                    LnkLogOut.Click();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



    }
}
