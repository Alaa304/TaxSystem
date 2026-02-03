using AutoMapper;
using Core.Domain.Entities;
using Core.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Role;
using Shared.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public RolesController(IRoleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            var result = await _service.AddRoleAsync(role);
            var responseDto = _mapper.Map<RoleResponseDto>(result);

            return Ok(new ApiResponse<RoleResponseDto>(
                responseDto,
                "تم إضافة الدور بنجاح"
            ));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _service.GetAllRolesAsync();
            var dtos = _mapper.Map<IEnumerable<RoleResponseDto>>(roles);

            return Ok(new ApiResponse<IEnumerable<RoleResponseDto>>(dtos));
        }
    }
}
