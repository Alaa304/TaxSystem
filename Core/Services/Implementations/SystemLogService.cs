using Core;
using Core.Domain.Entities;
using Core.Services.Abstraction;

namespace Infrastructure.Services.Implementations
{
    /// <summary>
    /// خدمة تسجيل العمليات (System Logs)
    /// </summary>
    public class SystemLogService : ISystemLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SystemLog> AddLogAsync(SystemLog log)
        {
            await _unitOfWork.GetRepository<SystemLog, int>().AddAsync(log);
            await _unitOfWork.SaveChangesAsync();
            return log;
        }

        public async Task<IEnumerable<SystemLog>> GetAllLogsAsync()
        {
            return await _unitOfWork
                .GetRepository<SystemLog, int>()
                .GetAllAsync(true);
        }
    }
}
