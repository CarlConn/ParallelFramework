using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ParallelFramework.Base;
using ParallelFramework.Config;
using ParallelFramework.UnitTestPages;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.ClassLevel)]

namespace ParallelFramework.UnitTests
{

    [TestClass]
    public class LogInTests : TestInitialize
    {

        [TestMethod]
        public void LogInPageTestPositive()
        {
            Driver.Navigate().GoToUrl(Settings.AUT);
            HomePage homePage = new HomePage(Driver);
            homePage.HomePageAssertPresent();
            BannerPage bannerPage = new BannerPage(Driver);
            LogInPage logInPage = bannerPage.BannerPageClickLogInLink();
            logInPage.LogInPagAssertPresent();
            logInPage.LogInPageEnterUserName(Settings.UserName);
            logInPage.LogInPageEnterPassWord(Settings.PassWord);
            homePage = logInPage.LogInPagePressLogIn();
            bannerPage.BannerPageAssertLoggedIn();
            bannerPage.BannerPagePressLogOutLink();
            bannerPage.BannerPageAssertSignedOut();
        }

        [TestMethod]
        public void LogInPageTestNegative()
        {
            Driver.Navigate().GoToUrl(Settings.AUT);
            HomePage homePage = new HomePage(Driver);
            homePage.HomePageAssertPresent();
            BannerPage bannerPage = new BannerPage(Driver);
            LogInPage logInPage = bannerPage.BannerPageClickLogInLink();
            logInPage.LogInPagAssertPresent();
            logInPage.LogInPageEnterUserName("Bob");
            logInPage.LogInPageEnterPassWord("Bob");
            homePage = logInPage.LogInPagePressLogIn();
            logInPage.LogInPageAssertInvalidPresent();
        }

    }
}
