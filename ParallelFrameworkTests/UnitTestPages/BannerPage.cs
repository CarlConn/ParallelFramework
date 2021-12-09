using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ParallelFramework.Base;
using ParallelFramework.Config;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace ParallelFrameworkTests.UnitTestPages
{
    public class BannerPage : BasePage
    {
        public BannerPage(IWebDriver Driver) : base(Driver) { }

        private IWebElement LnkHome => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[1]/a"));
        private IWebElement LnkAbout => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[2]/a"));

        private IWebElement LnkEmployeeList => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[3]/a"));
        private IWebElement LnkRegister => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[2]/li[1]/a"));
        private IWebElement LnkLogIn => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[2]/li[2]/a"));

        private IWebElement LnkLogOut =>
            Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/form/ul/li[2]/a"));
        private IWebElement LnkHello =>
            Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/form/ul[1]/li/a"));

        private bool BannerPageIsPresent()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkAbout));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public void BannerPageAssertPresent()
        {
            bool result = BannerPageIsPresent();
            try
            {
                Assert.IsTrue(result, "Banner Page is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
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
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkAbout));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        private bool BannerPageIsEmployeeLinkPresent()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkEmployeeList));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        private bool BannerPageIsRegisterLinkPresent()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkRegister));
                result = false;
            }
            catch (TimeZoneNotFoundException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        private bool BannerPageIsLogOutLinkPresent()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(LnkLogOut));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public LogInPage BannerPageClickLogInLink()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(LnkLogIn)).Click();
            return new LogInPage(Driver);
        }

        public void BannerPageAssertLoggedIn()
        {
            string expectedText = "Hello" + Settings.UserName + "!";
            string actualText = LnkHello.Text;

            try
            {
                Assert.AreEqual(expectedText, actualText, "The member is not signed in");
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

        public void BannerPagePressSignOutLink()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(LnkLogOut)).Click();
        }

    }
}
