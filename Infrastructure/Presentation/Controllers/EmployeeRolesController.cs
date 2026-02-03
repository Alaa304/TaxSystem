using Core.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Infrastructure.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeRolesController : ControllerBase
    {
        private readonly IEmployeeRoleService _service;

        public EmployeeRolesController(IEmployeeRoleService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(int employeeId, int roleId)
        {
            await _service.AssignRoleToEmployeeAsync(employeeId, roleId);
            return Ok(new ApiResponse<string>("تم إسناد الدور للموظف بنجاح"));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRole(int employeeId, int roleId)
        {
            await _service.RemoveRoleFromEmployeeAsync(employeeId, roleId);
            return Ok(new ApiResponse<string>("تم حذف الدور من الموظف"));
        }
    }
}
