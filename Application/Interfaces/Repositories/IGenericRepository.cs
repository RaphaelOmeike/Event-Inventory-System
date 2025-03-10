using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        bool Exists(Func<T, bool> predicate);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        //Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        void Create(T entity);
        void Update(T entity);//study pagination project
    }
}
