using Core;
using Core.Domain.Entities;
using Core.Services.Abstraction;

namespace Infrastructure.Services.Implementations
{
    /// <summary>
    /// إدارة العلاقة بين Employees و Roles (Many-to-Many)
    /// </summary>
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AssignRoleToEmployeeAsync(int employeeId, int roleId)
        {
            var repo = _unitOfWork.GetRepository<EmployeeRole, int>();

            var exists = (await repo.GetAllAsync(true))
                .Any(er => er.EmployeeID == employeeId && er.RoleID == roleId);

            if (exists)
                throw new Exception("هذا الدور مُسند بالفعل لهذا الموظف.");

            var employeeRole = new EmployeeRole
            {
                EmployeeID = employeeId,
                RoleID = roleId
            };

            await repo.AddAsync(employeeRole);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveRoleFromEmployeeAsync(int employeeId, int roleId)
        {
            var repo = _unitOfWork.GetRepository<EmployeeRole, int>();

            var employeeRole = (await repo.GetAllAsync())
                .FirstOrDefault(er => er.EmployeeID == employeeId && er.RoleID == roleId);

            if (employeeRole == null)
                throw new Exception("الدور غير موجود لهذا الموظف.");

            repo.Delete(employeeRole);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeRole>> GetRolesByEmployeeIdAsync(int employeeId)
        {
            return (await _unitOfWork
                .GetRepository<EmployeeRole, int>()
                .GetAllAsync(true))
                .Where(er => er.EmployeeID == employeeId);
        }
    }
}
