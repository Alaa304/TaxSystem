using AutoMapper;
using Core;
using Core.Domain.Entities;
using Shared.DTOs;

namespace Infrastructure.Services;

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonResultDto>> GetAllAsync()
    {
        var persons = await _unitOfWork
            .GetRepository<Person, int>()
            .GetAllAsync(true);

        var result = _mapper.Map<IEnumerable<PersonResultDto>>(persons);

        return result;
    }

    public async Task<PersonResultDto?> GetByIdAsync(int id)
    {
        var person = await _unitOfWork
            .GetRepository<Person, int>()
            .GetByIdAsync(id);

        if (person is null)
            return null;

        return _mapper.Map<PersonResultDto>(person);
    }

    public async Task CreateAsync(PersonCreateDto dto)
    {
        var person = _mapper.Map<Person>(dto);

        await _unitOfWork
            .GetRepository<Person, int>()
            .AddAsync(person);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, PersonUpdateDto dto)
    {
        var repo = _unitOfWork.GetRepository<Person, int>();

        var person = await repo.GetByIdAsync(id);

        if (person is null)
            throw new Exception("Person not found");

        _mapper.Map(dto, person);

        repo.Update(person);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var repo = _unitOfWork.GetRepository<Person, int>();

        var person = await repo.GetByIdAsync(id);

        if (person is null)
            throw new Exception("Person not found");

        repo.Delete(person);

        await _unitOfWork.SaveChangesAsync();
    }
}
