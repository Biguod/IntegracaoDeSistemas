using System.Linq.Expressions;

namespace Avaliacao1.JonStore.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<Guid> Create(T model);
        Task Update(T model);
        Task Delete(T model);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(Guid id);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
    }
}
