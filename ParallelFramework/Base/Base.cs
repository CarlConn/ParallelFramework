using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFramework.Base
{
    public class Base
    {
        public readonly ParallelConfig _parallelConfig;

        public Base(ParallelConfig parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }
    }
}
