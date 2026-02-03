using AutoMapper;
using Core.Domain.Entities;
using Core.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Office;
using Shared.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeService _service;
        private readonly IMapper _mapper;

        public OfficesController(IOfficeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfficeDto dto)
        {
            var office = _mapper.Map<Office>(dto);
            var result = await _service.AddOfficeAsync(office);
            var responseDto = _mapper.Map<OfficeResponseDto>(result);

            return Ok(new ApiResponse<OfficeResponseDto>(
                responseDto,
                "تم إنشاء المكتب بنجاح"
            ));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var offices = await _service.GetAllOfficesAsync();
            var dtos = _mapper.Map<IEnumerable<OfficeResponseDto>>(offices);

            return Ok(new ApiResponse<IEnumerable<OfficeResponseDto>>(dtos));
        }
    }
}
