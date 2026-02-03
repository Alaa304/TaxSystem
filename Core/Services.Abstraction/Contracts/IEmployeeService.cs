using Core.Domain.Entities;

namespace Core.Services.Abstraction
{
    /// <summary>
    /// واجهة الخدمة لإدارة العمليات على جدول Employees
    /// </summary>
    public interface IEmployeeService
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeByIdAsync(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);
    }
}
