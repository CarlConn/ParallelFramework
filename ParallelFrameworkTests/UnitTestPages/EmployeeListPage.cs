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
    public class EmployeeListPage : BasePage
    {
        public EmployeeListPage(ParallelConfig parallelConfig) : base(parallelConfig) {}
        private IWebElement TxtSearchBox => _parallelConfig.Driver.FindElement(By.Name("searchTerm"));
        private IWebElement BtnSearch =>
            _parallelConfig.Driver.FindElement(By.XPath(".//input[@type='submit' and @value='Search']"));

        private bool EmployeeListPageIsPresent()
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

        public void EmployeeListPageAssertPresent()
        {
            bool result = EmployeeListPageIsPresent();
        }
    }
}
