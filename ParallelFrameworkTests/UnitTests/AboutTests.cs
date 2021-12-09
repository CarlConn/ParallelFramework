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
    public class AboutTests : TestInitialize
    {
        [TestMethod]
        public void AboutPageTests()
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
            bannerPage.BannerPagePressSignOutLink();
            bannerPage.BannerPageAssertSignedOut();
        }
    }
}
