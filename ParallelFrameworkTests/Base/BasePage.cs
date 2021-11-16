using ParallelFramework.Base;

namespace ParallelFrameworkTests.Base
{
    public abstract class BasePage : ParallelFramework.Base.Base
    {
        public BasePage(ParallelConfig parallelConfig) : base(parallelConfig){}
    }
}
