using AutoMapper;
using Core.Domain.Entities;
using Core.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.ArchiveDTOs;
using Shared.DTOs;

namespace Infrastructure.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivesController : ControllerBase
    {
        private readonly IArchiveService _service;
        private readonly IMapper _mapper;

        public ArchivesController(IArchiveService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArchiveDto dto)
        {
            var archive = _mapper.Map<Archive>(dto);
            await _service.AddArchiveAsync(archive);

            return Ok(new ApiResponse<string>(
                "تم حفظ السجل في الأرشيف"
            ));
        }
    }
}
