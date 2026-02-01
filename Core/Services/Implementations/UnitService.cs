using AutoMapper;
using Core;
using Core.Domain.Entities;

using Shared.DTOs;

namespace Infrastructure.Services;

public class UnitService : IUnitService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UnitService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UnitResultDto>> GetAllAsync()
    {
        var units = await _unitOfWork
            .GetRepository<Unit, int>()
            .GetAllAsync(true);

        return _mapper.Map<IEnumerable<UnitResultDto>>(units);
    }

    public async Task<UnitResultDto?> GetByIdAsync(int id)
    {
        var unit = await _unitOfWork
            .GetRepository<Unit, int>()
            .GetByIdAsync(id);

        if (unit is null)
            return null;

        return _mapper.Map<UnitResultDto>(unit);
    }

    public async Task CreateAsync(UnitCreateDto dto)
    {
        var unit = _mapper.Map<Unit>(dto);

        await _unitOfWork
            .GetRepository<Unit, int>()
            .AddAsync(unit);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, UnitUpdateDto dto)
    {
        var repo = _unitOfWork.GetRepository<Unit, int>();
        var unit = await repo.GetByIdAsync(id);

        if (unit is null)
            throw new Exception("Unit not found");

        _mapper.Map(dto, unit);

        repo.Update(unit);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var repo = _unitOfWork.GetRepository<Unit, int>();
        var unit = await repo.GetByIdAsync(id);

        if (unit is null)
            throw new Exception("Unit not found");

        repo.Delete(unit);
        await _unitOfWork.SaveChangesAsync();
    }
}
