using AutoMapper;
using Core.Domain.Entities;
using Core.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Employee;
using Shared.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            var result = await _service.AddEmployeeAsync(employee);
            var responseDto = _mapper.Map<EmployeeResponseDto>(result);

            return Ok(new ApiResponse<EmployeeResponseDto>(responseDto, "تم إضافة الموظف بنجاح"));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound(new ApiResponse<EmployeeResponseDto>("الموظف غير موجود"));

            var dto = _mapper.Map<EmployeeResponseDto>(employee);
            return Ok(new ApiResponse<EmployeeResponseDto>(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAllEmployeesAsync();
            var dtos = _mapper.Map<IEnumerable<EmployeeResponseDto>>(employees);

            return Ok(new ApiResponse<IEnumerable<EmployeeResponseDto>>(dtos));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            employee.Id = id;
            await _service.UpdateEmployeeAsync(employee);

            return Ok(new ApiResponse<string>("تم تحديث بيانات الموظف بنجاح"));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteEmployeeAsync(id);
            return Ok(new ApiResponse<string>("تم حذف الموظف بنجاح"));
        }
    }
}
