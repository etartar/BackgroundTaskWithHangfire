using System.Threading.Tasks;

namespace BackgroundTaskWithHangfire.Services
{
    public interface IEmployeeService
    {
        Task<bool> InsertAsync();
    }
}
