using API.Models;
using System.Linq.Expressions;

namespace API.Core.IRepository
{
    public interface IRepository<T> where T : class
    {

        Task<T> FindByKeyAsync(params object[] key);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> expr = null);
        Task<T> AddAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expr = null);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expr = null);
        Task<int> CountAsync(Expression<Func<T, bool>> expr = null);
        void Update(T entity);
        void Delete(T entity);
        void AddRange(List<T> entity);
        void UpdateRange(List<T> entity);
        void DeleteRange(List<T> entity);
        void Save();
    }
}
