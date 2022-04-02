using BackgroundTaskWithHangfire.Models;
using Microsoft.EntityFrameworkCore;

namespace BackgroundTaskWithHangfire.Contexts
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
