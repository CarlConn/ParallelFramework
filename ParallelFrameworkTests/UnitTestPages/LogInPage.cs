using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ParallelFramework.Base;

namespace ParallelFrameworkTests.UnitTestPages
{
    class LogInPage : BasePage
    {
        public LogInPage(IWebDriver Driver) : base(Driver) { }

        private IWebElement TxtUserName => Driver.FindElement(By.XPath(".//div[@class='col-md-10']/input"));
        private IWebElement TxtPassWord => Driver.FindElement(By.XPath("//*[@id='Password']"));
        private IWebElement BtnLogIn => Driver.FindElement(By.XPath("//*[@id='loginForm'']/form/div[4]/div/input"));

        private bool LogInPageIsPresent()
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

        public void LogInPagAssertPresent()
        {
            bool result = LogInPageIsPresent();
        }

        public void LogInPageEnterUserName(string userName)
        {
            TxtUserName.SendKeys(userName);
        }

        public void LogInPageEnterPassWord(string passWord)
        {
            TxtPassWord.SendKeys(passWord);
        }

        public EmployeeListPage LogInPagePressLogIn()
        {
            BtnLogIn.Click();
            return new EmployeeListPage(Driver);
        }
    }
}