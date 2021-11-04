using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParallelFramework.Base;

namespace ParallelFramework.Config
{
    public static class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            Settings.AUT = EATestConfiguration.EASettings.TestSettings["staging"].AUT;
            //Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = EATestConfiguration.EASettings.TestSettings["staging"].TestType;
            Settings.IsLog = EATestConfiguration.EASettings.TestSettings["staging"].IsLog;
            //Settings.IsReporting = EATestConfiguration.EASettings.TestSettings["staging"].IsReadOnly;
            Settings.LogPath = EATestConfiguration.EASettings.TestSettings["staging"].LogPath;
            Settings.AppConnectionString = EATestConfiguration.EASettings.TestSettings["staging"].AUTDBConnectionString;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), EATestConfiguration.EASettings.TestSettings["staging"].Browser);
        }
    }
}
