using BackgroundTaskWithHangfire.Contexts;
using BackgroundTaskWithHangfire.Extensions;
using BackgroundTaskWithHangfire.Jobs;
using BackgroundTaskWithHangfire.Services;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundTaskWithHangfire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackgroundTaskWithHangfire", Version = "v1" });
            });
            services.AddDbContext<EmployeeDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("EmployeeDbConnection")));
            
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("EmployeeDbConnection")));
            GlobalConfiguration.Configuration.UseSqlServerStorage(Configuration.GetConnectionString("EmployeeDbConnection")).WithJobExpirationTimeout(TimeSpan.FromDays(7));

            services.AddJobManager().AddCustomRecurringJob<TestJob>();

            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackgroundTaskWithHangfire v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            #region [Configure Hangfire]
            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                AppPath = null,
                DashboardTitle = "Hangfire Dashboard",
                Authorization = new[]
                {
                    new HangfireCustomBasicAuthenticationFilter
                    {
                        User = Configuration.GetSection("HangfireCredentials:UserName").Value,
                        Pass = Configuration.GetSection("HangfireCredentials:Password").Value
                    }
                }
            });

            //app.StartRecurringJobs();

            app.UseHangfireJobs();
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
