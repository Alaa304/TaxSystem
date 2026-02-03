using Core.Domain.Entities;

namespace Core.Services.Abstraction
{
    /// <summary>
    /// واجهة الخدمة لإدارة العمليات على جدول EmployeeRoles
    /// </summary>
    public interface IEmployeeRoleService
    {
        Task AssignRoleToEmployeeAsync(int employeeId, int roleId);
        Task RemoveRoleFromEmployeeAsync(int employeeId, int roleId);
        Task<IEnumerable<EmployeeRole>> GetRolesByEmployeeIdAsync(int employeeId);
    }
}
