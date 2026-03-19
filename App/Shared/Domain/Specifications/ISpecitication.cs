using System.Linq.Expressions;

namespace Backend.App.Shared.Domain.Specifications;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
}