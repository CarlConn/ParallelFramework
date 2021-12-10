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
        public void AboutPageHeaderText()
        {
            Driver.Navigate().GoToUrl(Settings.AUT);
            BannerPage bannerPage = new BannerPage(Driver);
            bannerPage.BannerPageAssertPresent();
            bannerPage.BannerPageAssertAboutLinkPresent();
            AboutPage aboutPage = bannerPage.BannerPagePressAboutPageLink();
            aboutPage.AboutPageAssertPresent();
            aboutPage.AboutPageAssertHeaderText();
        }

        [TestMethod]
        public void AboutPageSustenanceText()
        {
            Driver.Navigate().GoToUrl(Settings.AUT);
            BannerPage bannerPage = new BannerPage(Driver);
            bannerPage.BannerPageAssertPresent();
            bannerPage.BannerPageAssertAboutLinkPresent();
            AboutPage aboutPage = bannerPage.BannerPagePressAboutPageLink();
            aboutPage.AboutPageAssertPresent();
            aboutPage.AboutPageAssertSentenceText();
        }
    }
}
