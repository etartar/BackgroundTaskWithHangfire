using Hangfire;
using System.Collections.Generic;

namespace BackgroundTaskWithHangfire
{
    public class RecurringJobManager
    {
        private readonly IRecurringJobManager _manager;
        private readonly IEnumerable<IRecurringJob> _jobs;

        public RecurringJobManager(IRecurringJobManager manager, IEnumerable<IRecurringJob> jobs)
        {
            _manager = manager;
            _jobs = jobs;
        }

        public void Start()
        {
            foreach (var job in _jobs)
            {
                _manager.AddOrUpdate(job.JobId, () => job.Execute(), job.CronExpression);
            }
        }
    }
}
