using Core.Domain.Entities;

namespace Core.Services.Abstraction
{
    /// <summary>
    /// واجهة الخدمة لإدارة العمليات على جدول Archives
    /// </summary>
    public interface IArchiveService
    {
        Task<Archive> AddArchiveAsync(Archive archive);
        Task<IEnumerable<Archive>> GetAllArchivesAsync();
    }
}
