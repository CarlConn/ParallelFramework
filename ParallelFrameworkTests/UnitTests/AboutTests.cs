using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelFramework.Base;
using ParallelFramework.Config;
using ParallelFramework.Helpers;
using ParallelFramework.Reports;
using ParallelFrameworkTests.UnitTestPages;

namespace ParallelFrameworkTests.UnitTests
{
    [TestClass]
    public class AboutTests : TestInitialize
    {
        [TestMethod]
        public void AboutPageHeaderText()
        {
            //Reporter.StartReporter();
            //ExcelHelpers.PopulateInCollection("/SpreadSheet/Upgrade.xlsx");
            //string name = ExcelHelpers.ReadData(1, "Value");
            Driver.Navigate().GoToUrl(Settings.AUT);
            BannerPage bannerPage = new BannerPage(Driver);
            bannerPage.BannerPageAssertPresent();
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
            AboutPage aboutPage = bannerPage.BannerPagePressAboutPageLink();
            aboutPage.AboutPageAssertPresent();
            aboutPage.AboutPageAssertSentenceText();
        }
    }
}
