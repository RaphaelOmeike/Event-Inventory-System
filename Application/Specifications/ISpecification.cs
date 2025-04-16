using System.Linq.Expressions;

namespace Infrastructure.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSplitQuery { get; }
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
    }
}
