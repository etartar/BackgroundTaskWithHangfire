using BackgroundTaskWithHangfire.Services;
using Hangfire;
using System.Threading.Tasks;

namespace BackgroundTaskWithHangfire.Jobs
{
    public class EmployeeJob
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeJob(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            RecurringJob.AddOrUpdate(() => ProcessInsertEmployeeJob(), "*/1 * * * *");
        }

        public async Task<bool> ProcessInsertEmployeeJob()
        {
            bool result = await _employeeService.InsertAsync();

            return result;
        }
    }
}
