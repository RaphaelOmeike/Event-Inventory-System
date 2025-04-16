using Infrastructure.Specifications;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<int> GetCountAsync();
        IReadOnlyList<T> FindWithSpecificationPattern(ISpecification<T> specification = null);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);
        Task CreateAsync(T entity);
        void Update(T entity);//study pagination project
    }
}
