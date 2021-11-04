using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParallelFramework.Base;

namespace ParallelFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("buildName")]
        public string BuildName { get; set; }


        [JsonProperty("aut")]
        public string AUT { get; set; }


        [JsonProperty("testType")]
        public string TestType { get; set; }


        [JsonProperty("isLog")]
        public string IsLog { get; set; }


        [JsonProperty("logPath")]
        public string LogPath { get; set; }


        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }

    }
}
