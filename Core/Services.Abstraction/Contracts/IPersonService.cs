
using Shared.DTOs;
namespace Core;

public interface IPersonService
{
    Task<IEnumerable<PersonResultDto>> GetAllAsync();

    Task<PersonResultDto?> GetByIdAsync(int id);

    Task CreateAsync(PersonCreateDto dto);

    Task UpdateAsync(int id, PersonUpdateDto dto);

    Task DeleteAsync(int id);
}