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
    public class EmployeeListPage : BasePage
    {
        public EmployeeListPage(IWebDriver Driver) : base(Driver) {}
        private IWebElement TxtSearchBox => Driver.FindElement(By.Name("searchTerm"));
        private IWebElement BtnSearch => Driver.FindElement(By.XPath(".//input[@type='submit' and @value='Search']"));

        private bool EmployeeListPageIsPresent()
        {
            bool result = false;
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(BtnSearch));
                result = true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public void EmployeeListPageAssertPresent()
        {
            bool result = EmployeeListPageIsPresent();
            try
            {
                Assert.IsTrue(result, "Employee List Page is not present");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
