using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using ParallelFramework.Base;
using ParallelFramework.Reports;
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
                Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Employee List Page Search Buton");
                Wait.Until(ExpectedConditions.ElementToBeClickable(BtnSearch));
                Reporter.LogTestStepForBugLogger(Status.Info, "Employee List Page Search Button present");
                result = true;
            }
            catch (TimeoutException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Employee List Page Search Button not Present. {e.Message}");
            }

            return result;
        }

        public void EmployeeListPageAssertPresent()
        {
            bool result = EmployeeListPageIsPresent();
            try
            {
                Assert.IsTrue(result, "Employee List Page is not present");
                Reporter.LogPassingTestStepToBugLogger("Employee List Page Present Assertion passed");
            }
            catch (AssertFailedException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Employee List Page Present Asserttion Failed. {e.Message}");
            }
        }

        public void EmployeeListPageEnterSearchText(string text)
        {
            Reporter.LogTestStepForBugLogger(Status.Info, $"Employee Page Search Box entered {text}");
            TxtSearchBox.SendKeys(text);
        }

        public void EmployeeListPagePressSearchButton()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Waiting for Employee List Page Search Button");
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
                Reporter.LogPassingTestStepToBugLogger("Employee ListPage First Row text is correct");
            }
            catch (AssertFailedException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Employee List Page First Row is not correct. {e.Message}");
            }
        }

        public void EmployeeListPageAssertFirstRowBlank()
        {
            int actualCount = EmployeeListPageReturnNumberOfRows();
            int expectedCount = 0;
            try
            {
                Assert.AreEqual(expectedCount, actualCount, "Employee List Page table row count not correct");
                Reporter.LogPassingTestStepToBugLogger("Employee List Page table row is correct");
            }
            catch (AssertFailedException e)
            {
                Reporter.LogTestStepForBugLogger(Status.Fail, $"Employee List Page Row Count not correct. {e.Message}");
            }
        }

    }
}
