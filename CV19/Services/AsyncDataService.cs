using System;
using System.Threading;
using CV19.Services.Interfaces;

namespace CV19.Services
{
    internal class AsyncDataService : IAsyngDataService
    {
        private const int __SLEEPTIME = 7000;
        public string GetResult(DateTime time)
        {
            Thread.Sleep(__SLEEPTIME);

            return $"Result value {time}";
        }
    }
}
