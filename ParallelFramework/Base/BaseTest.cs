using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelFramework.Config;


namespace ParallelFramework.Base
{
    [TestClass]
    public class BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            TestInitialize.InitializeSettings();
         
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
