using Core;
using Core.Domain.Entities;
using Core.Services.Abstraction;

namespace Infrastructure.Services.Implementations
{
    /// <summary>
    /// تطبيق خدمة إدارة Roles
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            var existing = await _unitOfWork
                .GetRepository<Role, int>()
                .GetAllAsync(true);

            if (existing.Any(r => r.RoleName == role.RoleName))
                throw new Exception($"الدور '{role.RoleName}' موجود بالفعل");

            await _unitOfWork.GetRepository<Role, int>().AddAsync(role);
            await _unitOfWork.SaveChangesAsync();

            return role;
        }

        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _unitOfWork
                .GetRepository<Role, int>()
                .GetByIdAsync(roleId);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _unitOfWork
                .GetRepository<Role, int>()
                .GetAllAsync(true);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _unitOfWork.GetRepository<Role, int>().Update(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var role = await GetRoleByIdAsync(roleId);
            if (role == null)
                throw new Exception($"Role with ID {roleId} not found.");

            _unitOfWork.GetRepository<Role, int>().Delete(role);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
