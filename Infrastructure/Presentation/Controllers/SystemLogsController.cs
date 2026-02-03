using AutoMapper;
using Core.Domain.Entities;
using Core.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.SystemLog;
using Shared.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SystemLogsController : ControllerBase
    {
        private readonly ISystemLogService _service;
        private readonly IMapper _mapper;

        public SystemLogsController(ISystemLogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSystemLogDto dto)
        {
            var log = _mapper.Map<SystemLog>(dto);
            await _service.AddLogAsync(log);

            return Ok(new ApiResponse<string>("تم تسجيل العملية في النظام"));
        }
    }
}
