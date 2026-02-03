using Core.Domain.Entities;

namespace Core.Services.Abstraction
{
    /// <summary>
    /// واجهة الخدمة لإدارة العمليات على جدول SystemLogs
    /// </summary>
    public interface ISystemLogService
    {
        Task<SystemLog> AddLogAsync(SystemLog log);
        Task<IEnumerable<SystemLog>> GetAllLogsAsync();
    }
}
