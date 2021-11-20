﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ParallelFramework;
using ParallelFramework.Base;

namespace ParallelFrameworkTests.UnitTestPages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver Driver) : base(Driver) { }

        private IWebElement BtnLearnMore => Driver.FindElement(By.XPath((".//div[@class='col-md-4']/p[2]/a")));
        
        private bool HomePageIsPresent()
        {
            bool result = false;
            try
            {

            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        public void HomePageAssertPresent()
        {
            bool result = HomePageIsPresent();
        }
    }
}
