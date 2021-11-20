using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ParallelFramework.Base;

namespace ParallelFrameworkTests.UnitTestPages
{
    public class AboutPage : BasePage
    {
        public AboutPage(IWebDriver Driver) : base(Driver) {}

        private IWebElement TxtAbout => Driver.FindElement(By.XPath(".//div[@class='container body-content']/h2"));

        private bool AboutPageIsPresent()
        {
            bool result = false;
            try
            {
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        public void AboutPageAssertPresent()
        {
            bool result = AboutPageIsPresent();
        }
    }
}
