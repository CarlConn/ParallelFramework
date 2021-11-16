using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ParallelFramework.Base;

namespace ParallelFramework.Config
{
    public static class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot configurationRoot = builder.Build();

            Settings.AUT = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUT;
            Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            Settings.IsLog = configurationRoot.GetSection("testSettings").Get<TestSettings>().IsLog;
            Settings.LogPath = configurationRoot.GetSection("testSettings").Get<TestSettings>().LogPath;
            Settings.BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;
        }
    }
}
