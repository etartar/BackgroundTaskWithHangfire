using Hangfire;
using System;
using System.Diagnostics;

namespace BackgroundTaskWithHangfire.Jobs
{
    public class ContinuationsJob
    {
        public ContinuationsJob()
        {
            /// Delayed Job
            var parentJobId = BackgroundJob.Schedule(() => ProcessParentJob(), TimeSpan.FromMinutes(4));

            /// Continuations Job
            BackgroundJob.ContinueJobWith(parentJobId, () => ProcessContinuationsJob());
        }

        public void ProcessParentJob()
        {
            Debug.WriteLine("I am a Delayed Job !!");
        }

        public void ProcessContinuationsJob()
        {
            Debug.WriteLine("I am a Recurring Job !!");
        }
    }
}
