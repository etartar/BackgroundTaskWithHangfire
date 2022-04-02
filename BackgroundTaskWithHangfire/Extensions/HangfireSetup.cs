using BackgroundTaskWithHangfire.Jobs;
using BackgroundTaskWithHangfire.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundTaskWithHangfire.Extensions
{
    public static class HangfireSetup
    {
        public static void UseHangfireJobs(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var employeeService = serviceProvider.GetService<EmployeeService>();
            var employeeJob = new EmployeeJob(employeeService);

            //var fireAndForgetJob = new FireAndForgetJob();
            //var delayedJob = new DelayedJob();
            //var recurringJob = new Recurring_Job();
            var continuationsJob = new ContinuationsJob();
        }
    }
}
