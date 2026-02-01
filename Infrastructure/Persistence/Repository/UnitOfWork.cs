using System.Collections.Concurrent;
using Core;
using Core.Domain.Entities;
using Presistence.Data;

namespace Infrastructure;

 public class UnitOfWork : IUnitOfWork
 {
private readonly TaxDbContext _context;

 private ConcurrentDictionary<string, object> _repositories;
 public UnitOfWork(TaxDbContext context)
 {
 _context = context;
 _repositories = new();
 }
public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
 =>(IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, 
(_)=>new GenericRepository<TEntity, TKey>(_context));


 public async Task<int> SaveChangesAsync()
=>await _context.SaveChangesAsync();

 /*public void Dispose()
    {
        _context.Dispose();
    }*/
}

