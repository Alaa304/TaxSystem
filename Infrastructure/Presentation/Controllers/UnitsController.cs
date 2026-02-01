using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Infrastructure.Services; // IUnitService
using Core; // IUnitOfWork لو حابة تستخدم Service Manager لاحقًا

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitsController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitResultDto>>> GetAllUnits()
        {
            var units = await _unitService.GetAllAsync();
            return Ok(units);
        }

        // GET: api/Units/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UnitResultDto>> GetUnitById(int id)
        {
            var unit = await _unitService.GetByIdAsync(id);
            if (unit is null)
                return NotFound(new { message = "Unit not found" });

            return Ok(unit);
        }

        // POST: api/Units
        [HttpPost]
        public async Task<ActionResult> CreateUnit([FromBody] UnitCreateDto dto)
        {
            await _unitService.CreateAsync(dto);
            // لو DTO بعد الإنشاء بيرجع Id ممكن نعمل:
            return CreatedAtAction(nameof(GetUnitById), new { id = dto.UnitNumber }, dto);
        }

        // PUT: api/Units/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUnit(int id, [FromBody] UnitUpdateDto dto)
        {
            try
            {
                await _unitService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Units/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUnit(int id)
        {
            try
            {
                await _unitService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
