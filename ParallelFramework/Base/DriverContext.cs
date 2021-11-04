using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFramework.Base
{
    public class DriverContext
    {
        public readonly ParallelConfig _parellelConfig;

        public DriverContext(ParallelConfig parellelConfig)
        {
            _parellelConfig = parellelConfig;
        }

        public static Browser Browser { get; set; }

    }
}
