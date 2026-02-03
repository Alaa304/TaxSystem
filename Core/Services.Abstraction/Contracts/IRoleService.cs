using Core.Domain.Entities;

namespace Core.Services.Abstraction
{
    /// <summary>
    /// واجهة الخدمة لإدارة العمليات على جدول Roles
    /// </summary>
    public interface IRoleService
    {
        Task<Role> AddRoleAsync(Role role);
        Task<Role?> GetRoleByIdAsync(int roleId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int roleId);
    }
}
