using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ParallelFramework.Base;
using ParallelFrameworkTests.Base;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace ParallelFrameworkTests.UnitTestPages
{
    public class BannerPage : BasePage
    {
        public BannerPage(ParallelConfig parallelConfig) : base(parallelConfig) { }

        private IWebElement LnkHome =>
            _parallelConfig.Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[1]/a"));

        private IWebElement LnkAbout =>
            _parallelConfig.Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[2]/a"));

        private IWebElement LnkEmployeeList =>
            _parallelConfig.Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[1]/li[3]/a"));
        private IWebElement LnkRegister =>
            _parallelConfig.Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[2]/li[1]/a"));
        private IWebElement LnkSignIn => _parallelConfig.Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[2]/li[2]/a"));

        private bool BannerPageIsPresent()
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

        public void BannerPageAssertPresent()
        {
            bool result = BannerPageIsPresent();
        }
    }
}
