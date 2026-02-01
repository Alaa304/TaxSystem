using Core.Domain.Entities;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

internal static class SpecificationEvaluator
{
    public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(
        IQueryable<TEntity> inputQuery,
        ISpecifications<TEntity, TKey> spec)
        where TEntity : BaseEntity<TKey>
    {
        var query = inputQuery;

        // WHERE
        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);

        // INCLUDE
        if (spec.IncludeExpressions.Count > 0)
        {
            query = spec.IncludeExpressions.Aggregate(
                query,
                (current, include) => current.Include(include));
        }

        // ORDER BY
        if (spec.OrderBy != null)
            query = query.OrderBy(spec.OrderBy);

        else if (spec.OrderByDescending != null)
            query = query.OrderByDescending(spec.OrderByDescending);

        // PAGINATION
        if (spec.IsPaginated)
            query = query.Skip(spec.Skip).Take(spec.Take);

        return query;
    }
}
