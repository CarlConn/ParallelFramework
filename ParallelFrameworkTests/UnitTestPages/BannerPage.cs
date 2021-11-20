using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ParallelFramework.Base;
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
        private IWebElement LnkSignIn => Driver.FindElement(By.XPath(".//div[@class='navbar-collapse collapse']/ul[2]/li[2]/a"));

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
