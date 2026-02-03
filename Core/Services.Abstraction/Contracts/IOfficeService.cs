using Core.Domain.Entities;

namespace Core.Services.Abstraction
{
    /// <summary>
    /// واجهة الخدمة لإدارة العمليات على جدول Offices
    /// </summary>
    public interface IOfficeService
    {
        Task<Office> AddOfficeAsync(Office office);
        Task<Office?> GetOfficeByIdAsync(int officeId);
        Task<IEnumerable<Office>> GetAllOfficesAsync();
        Task UpdateOfficeAsync(Office office);
        Task DeleteOfficeAsync(int officeId);
    }
}
