using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFramework.Reports
{
    class NamespaceSetUp
    {
        [TestClass]
        public static class NamespaceSetup
        {
            [AssemblyInitialize]
            public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
            {
                Reporter.StartReporter();
            }
        }
    }
}
