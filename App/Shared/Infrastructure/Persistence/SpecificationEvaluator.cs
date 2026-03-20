using Backend.App.Shared.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Backend.App.Shared.Infrastructure.Persistence;

public class SpecificationEvaluator<TEntity> where TEntity : class
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
    {
        var query = inputQuery;
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        query = query.OrderBy(x => EF.Property<int>(x, "Id"));
        if (spec.IsPagingEnabled) query = query.Skip(spec.Skip).Take(spec.Take);
        return query;
    }
}