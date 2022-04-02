using BackgroundTaskWithHangfire.Contexts;
using BackgroundTaskWithHangfire.Models;
using System;
using System.Threading.Tasks;

namespace BackgroundTaskWithHangfire.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeService(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<bool> InsertAsync()
        {
            try
            {
                Employee employee = new Employee
                {
                    EmployeeName = "Emir TARTAR",
                    Designation = "Senior Software Developer",
                    CreatedDate = DateTime.Now,
                };

                await _employeeDbContext.AddAsync(employee);
                await _employeeDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
