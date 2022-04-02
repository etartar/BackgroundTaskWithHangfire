using Hangfire;
using System;

namespace BackgroundTaskWithHangfire.Jobs
{
    public class FireAndForgetJob
    {
        public FireAndForgetJob()
        {
            /// Job create edildikten sonra çalışır ve process olur.
            var jobId = BackgroundJob.Enqueue(() => ProcessFireAndForgetJob());
        }

        public void ProcessFireAndForgetJob()
        {
            Console.WriteLine("I am a Fire and Forget Job !!");
        }
    }
}
