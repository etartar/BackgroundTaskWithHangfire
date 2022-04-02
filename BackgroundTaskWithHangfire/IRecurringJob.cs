using System.Threading.Tasks;

namespace BackgroundTaskWithHangfire
{
    public interface IRecurringJob
    {
        string CronExpression { get; }
        string JobId { get; }
        Task Execute();
    }
}
