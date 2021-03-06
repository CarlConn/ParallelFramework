using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using ParallelFramework.Base;
using SeleniumExtras.WaitHelpers;

namespace ParallelFrameworkTests.UnitTestPages
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
                Wait.Until(ExpectedConditions.ElementToBeClickable(BtnLogIn));
                result = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public void LogInPagAssertPresent()
        {
            bool result = LogInPageIsPresent();
            try
            {
                Assert.IsTrue(result, "Log In Page is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LogInPageEnterUserName(string userName)
        {
            TxtUserName.SendKeys(userName);
        }

        public void LogInPageEnterPassWord(string passWord)
        {
            TxtPassWord.SendKeys(passWord);
        }

        public HomePage LogInPagePressLogIn()
        {
            BtnLogIn.Click();
            return new HomePage(Driver);
        }

        public bool LogInPageIsInvalidPresent()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath(".//div[@class='validation-summary-errors text-danger']/ul/li")));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public void LogInPageAssertInvalidPresent()
        {
            bool result = LogInPageIsInvalidPresent();
            try
            {
                Assert.IsTrue(result, "Log In Page Invalid is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}