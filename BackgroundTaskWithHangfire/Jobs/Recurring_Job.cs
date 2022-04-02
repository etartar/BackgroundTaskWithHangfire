using Hangfire;
using System;

namespace BackgroundTaskWithHangfire.Jobs
{
    public class Recurring_Job
    {
        public Recurring_Job()
        {
            /// Tekrar eden task'lar için kullanılan bir job türü. Örneğin, her saat başı çalışmasını istediğiniz bir job'a ihtiyacınız
            /// olduğun da aşağıdaki gibi tanımlayabiliriz.
            RecurringJob.AddOrUpdate(() => ProcessRecurringJob(), Cron.Hourly);
        }

        public void ProcessRecurringJob()
        {
            Console.WriteLine("I am a Recurring Job !!");
        }
    }
}
