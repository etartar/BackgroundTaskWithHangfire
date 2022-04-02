using System;
using System.Threading.Tasks;

namespace BackgroundTaskWithHangfire.Jobs
{
    public class TestJob : IRecurringJob
    {
        public string CronExpression => "*/1 * * * *";

        public string JobId => $"TestJob-{DateTime.Now}";

        public async Task Execute()
        {
            Console.WriteLine("Testjob start.");

            await Task.Delay(1000);

            Console.WriteLine("Testjob end.");
        }
    }
}
