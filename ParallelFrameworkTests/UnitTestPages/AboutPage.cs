using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ParallelFramework.Base;
using ParallelFrameworkTests.Base;

namespace ParallelFrameworkTests.UnitTestPages
{
    public class AboutPage : BasePage
    {
        public AboutPage(ParallelConfig parallelConfig) : base(parallelConfig) {}

        private IWebElement TxtAbout =>
            _parallelConfig.Driver.FindElement(By.XPath(".//div[@class='container body-content']/h2"));

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
