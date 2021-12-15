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
    public class EmployeeListTests : TestInitialize
    {
        [TestMethod]
        public void SearchForEmployee()
        {
            Driver.Navigate().GoToUrl(Settings.AUT);
            HomePage homePage = new HomePage(Driver);
            homePage.HomePageAssertPresent();
            BannerPage bannerPage = new BannerPage(Driver);
            bannerPage.BannerPageAssertPresent();
            bannerPage.BannerPageAssertLogInLinkPresent();
            LogInPage logInPage = bannerPage.BannerPageClickLogInLink();
            logInPage.LogInPagAssertPresent();
            logInPage.LogInPageEnterUserName(Settings.UserName);
            logInPage.LogInPageEnterPassWord(Settings.PassWord);
            homePage = logInPage.LogInPagePressLogIn();
            bannerPage.BannerPageAssertLoggedIn();
            bannerPage.BannerPageAssertEmployeeListLinkPresent();
            EmployeeListPage employeeListPage = bannerPage.BannerPageClickEmployeeListLink();
            employeeListPage.EmployeeListPageAssertPresent();
            employeeListPage.EmployeeListPageEnterSearchText("Ramesh");
            employeeListPage.EmployeeListPagePressSearchButton();
            employeeListPage.EmployeeListPageAssertFirstRowName("Ramesh");
            bannerPage.BannerPagePressLogOutLink();
            bannerPage.BannerPageAssertSignedOut();
            homePage.HomePageAssertPresent();
        }

        [TestMethod]
        public void SearchForEmployeeBlank()
        {
            Driver.Navigate().GoToUrl(Settings.AUT);
            HomePage homePage = new HomePage(Driver);
            homePage.HomePageAssertPresent();
            BannerPage bannerPage = new BannerPage(Driver);
            bannerPage.BannerPageAssertPresent();
            bannerPage.BannerPageAssertLogInLinkPresent();
            LogInPage logInPage = bannerPage.BannerPageClickLogInLink();
            logInPage.LogInPagAssertPresent();
            logInPage.LogInPageEnterUserName(Settings.UserName);
            logInPage.LogInPageEnterPassWord(Settings.PassWord);
            homePage = logInPage.LogInPagePressLogIn();
            bannerPage.BannerPageAssertLoggedIn();
            bannerPage.BannerPageAssertEmployeeListLinkPresent();
            EmployeeListPage employeeListPage = bannerPage.BannerPageClickEmployeeListLink();
            employeeListPage.EmployeeListPageAssertPresent();
            employeeListPage.EmployeeListPageEnterSearchText("Carl");
            employeeListPage.EmployeeListPagePressSearchButton();
            employeeListPage.EmployeeListPageAssertFirstRowBlank();
            bannerPage.BannerPagePressLogOutLink();
            bannerPage.BannerPageAssertSignedOut();
            homePage.HomePageAssertPresent();
        }

    }
}
