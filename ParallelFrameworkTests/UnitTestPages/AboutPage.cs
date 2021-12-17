using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ParallelFramework.Base;
using SeleniumExtras.WaitHelpers;

namespace ParallelFrameworkTests.UnitTestPages
{
    public class AboutPage : BasePage
    {
        public AboutPage(IWebDriver Driver) : base(Driver) {}
        private IWebElement TxtAbout => Driver.FindElement(By.CssSelector("body > div.container.body-content > h2"));
        private IWebElement TxtSentence => Driver.FindElement(By.CssSelector("body > div.container.body-content > p"));

        private bool AboutPageIsPresent()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class='container body-content']/h2")));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public void AboutPageAssertPresent()
        {
            bool result = AboutPageIsPresent();
            try
            {
                Assert.IsTrue(result, "About Page is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e);
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
