using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelFramework.Base;
using ParallelFramework.Config;
using ParallelFrameworkTests.UnitTestPages;

namespace ParallelFrameworkTests.UnitTests
{
    [TestClass]
    public class LogInTests : TestInitialize
    {
        [TestMethod]
        public void LogInPageTest()
        {
            Driver.Navigate().GoToUrl(Settings.AUT);
            LogInPage logInPage = new LogInPage(Driver);
            logInPage.LogInPagAssertPresent();
        }
    }
}
