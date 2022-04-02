using BackgroundTaskWithHangfire.CustomStates;
using Hangfire.Server;
using System;
using System.Threading.Tasks;

namespace BackgroundTaskWithHangfire.Jobs
{
    public abstract class WaitingAckJobBase
    {
        public Task Execute(PerformContext context, object[] args)
        {
            context.SetJobParameter(WaitingAckStateFilter.JOB_PARAMETER, true);
            PerformJob(context, args);
            return Task.CompletedTask;
        }

        protected abstract Task PerformJob(PerformContext context, object[] args);
    }
}
