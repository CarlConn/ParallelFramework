using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using ParallelFramework.Base;
using SeleniumExtras.WaitHelpers;

namespace ParallelFramework.UnitTestPages
{
    public class EmployeeListPage : BasePage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public EmployeeListPage(IWebDriver Driver) : base(Driver) { }
        private IWebElement TxtSearchBox => Driver.FindElement(By.Name("searchTerm"));
        private IWebElement BtnSearch => Driver.FindElement(By.XPath(".//input[@type='submit' and @value='Search']"));

        private IWebElement TxtFirstRowName =>
            Driver.FindElement(By.XPath(".//div[@class='container body-content']/table/tbody/tr[2]/td[1]"));

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

        public void EmployeeListPageEnterSearchText(string text)
        {
            TxtSearchBox.SendKeys(text);
        }

        public void EmployeeListPagePressSearchButton()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(BtnSearch)).Click();
        }

        public int EmployeeListPageReturnNumberOfRows()
        {
            IWebElement td = Driver.FindElement(By.XPath(".//div[@class='container body-content']/table/tbody/tr"));
            IList<IWebElement> tr = td.FindElements(By.TagName("tr"));
            int count = tr.Count;
            return count;
        }

        public string EmployeeListPageReturnFirstRowName()
        {
            string text = TxtFirstRowName.Text;
            return text;
        }


        public void EmployeeListPageAssertFirstRowName(string name)
        {
            string actualText = EmployeeListPageReturnFirstRowName();
            string expectedText = name;
            try
            {
                Assert.AreEqual(expectedText, actualText, "Employee List Page table first row name is not correct");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EmployeeListPageAssertFirstRowBlank()
        {
            int actualCount = EmployeeListPageReturnNumberOfRows();
            int expectedCount = 0;
            try
            {
                Assert.AreEqual(expectedCount, actualCount, "Employee List Page table row count not correct");
            }
            catch (AssertFailedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
