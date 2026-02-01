using Core;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;


namespace Infrastructure;

public class GenericRepository<TEntity, TKey>
    : IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
{
    private readonly TaxDbContext _dbcontext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(TaxDbContext dbcontext)
    {
        _dbcontext = dbcontext;
        _dbSet = _dbcontext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public void Delete(TEntity entity)
        => _dbSet.Remove(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false)
        => asNoTracking
            ? await _dbSet.AsNoTracking().ToListAsync()
            : await _dbSet.ToListAsync();

    public async Task<TEntity?> GetByIdAsync(TKey id)
        => await _dbSet.FindAsync(id);

    public void Update(TEntity entity)
        => _dbSet.Update(entity);
}
