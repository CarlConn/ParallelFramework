using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelFramework.Base;
using ParallelFramework.Config;
using ParallelFrameworkTests.UnitTestPages;
[assembly:Parallelize(Workers = 0, Scope = ExecutionScope.ClassLevel)]

namespace ParallelFrameworkTests.UnitTests
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

            WebElement logo=driver.Findelement (By.xpath(“//div[@id=’divLogo’]//img”));
            File file=logo.getScreenshotAs(OutputType.FILE);
            File destFile =new File(“logo.png”);
            FileUtils.copyFile(file,destfile);
        }

    }
}
