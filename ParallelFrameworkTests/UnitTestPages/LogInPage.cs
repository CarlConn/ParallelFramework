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
    class LogInPage : BasePage
    {
        public LogInPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }

        private IWebElement TxtUserName =>
            _parallelConfig.Driver.FindElement(By.XPath(".//div[@class='col-md-10']/input"));

        private IWebElement TxtPassWord => _parallelConfig.Driver.FindElement(By.XPath("//*[@id='Password']"));

        private IWebElement BtnLogIn =>
            _parallelConfig.Driver.FindElement(By.XPath("//*[@id='loginForm'']/form/div[4]/div/input"));

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
            return new EmployeeListPage(_parallelConfig);
        }
    }
}