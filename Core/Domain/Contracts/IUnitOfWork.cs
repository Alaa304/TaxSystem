using Core.Domain.Entities;

namespace Core;

 public interface IUnitOfWork
{
Task <int>SaveChangesAsync();
        //method return obj from IGenericRepository [Entity]
IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;

 }

