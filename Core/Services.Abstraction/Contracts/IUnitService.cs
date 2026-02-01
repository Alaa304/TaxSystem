using Shared.DTOs;

namespace Core;


public interface IUnitService
{
    Task<IEnumerable<UnitResultDto>> GetAllAsync();
    Task<UnitResultDto?> GetByIdAsync(int id);
    Task CreateAsync(UnitCreateDto dto);
    Task UpdateAsync(int id, UnitUpdateDto dto);
    Task DeleteAsync(int id);
}