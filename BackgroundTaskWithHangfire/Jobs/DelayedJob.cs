using Hangfire;
using System;

namespace BackgroundTaskWithHangfire.Jobs
{
    public class DelayedJob
    {
        public DelayedJob()
        {
            /// Belirli bir zaman bilgisi set edilerek sadece bir kez çalışmasını istediğimiz task'lar için kullanabileceğimiz job türü.
            var jobId = BackgroundJob.Schedule(() => ProcessDelayedJob(), TimeSpan.FromMinutes(4));
        }

        public void ProcessDelayedJob()
        {
            Console.WriteLine("I am a Delayed Job !!");
        }
    }
}
