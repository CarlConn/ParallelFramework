using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFramework.Base
{
    public class Browser
    {
        private readonly DriverContext driverContext;

        public Browser(DriverContext driver)
        {
            driverContext = driver;
        }
    }

    public enum BrowserType
    {
        Edge,
        InternetExplorer,
        FireFox,
        Chrome,
        Maximized,
        RestoredDown,
        iPhone,
        iPad
    }
}
