using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Debugger;
using OpenQA.Selenium.Support.UI;
using ParallelFramework;
using ParallelFramework.Base;
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
                Wait.Until(ExpectedConditions.ElementToBeClickable(BtnLearnMore));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public void HomePageAssertPresent()
        {
            bool result = HomePageIsPresent();
            try
            {
                Assert.IsTrue(result, "Home Page is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
