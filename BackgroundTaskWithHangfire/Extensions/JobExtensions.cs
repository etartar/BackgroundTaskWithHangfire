using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundTaskWithHangfire.Extensions
{
    public static class JobExtensions
    {
        public static JobConfiguration AddJobManager(this IServiceCollection services)
        {
            services.AddHangfireServer();
            services.AddSingleton<RecurringJobManager>();

            return new JobConfiguration(services);
        }

        public static IApplicationBuilder StartRecurringJobs(this IApplicationBuilder app)
        {
            var manager = app.ApplicationServices.CreateScope().ServiceProvider.GetService<RecurringJobManager>();
            manager.Start();
            return app;
        }
    }

    public class JobConfiguration
    {
        private readonly IServiceCollection _services;

        internal JobConfiguration(IServiceCollection services)
        {
            _services = services;
        }

        public JobConfiguration AddCustomRecurringJob<TJob>() where TJob : IRecurringJob
        {
            _services.AddSingleton(typeof(IRecurringJob), typeof(TJob));
            return this;
        }
    }
}
