using System;
using System.Threading.Tasks;
using Quartz;

namespace TestApply
{
    public class ShowDateTimeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var now = DateTime.Now.ToString("HH : mm : ss");
            Console.WriteLine($" Merhaba, saat şuan {now}");
            return Task.CompletedTask;
        }
    }
}


