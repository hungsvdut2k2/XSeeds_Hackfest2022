using API.Core.IRepository;
using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext _context;
        private readonly DbSet<T> entities;
        public Repository(DataContext context)
        {
            _context = context;
            this.entities = _context.Set<T>();
        }
        public async Task<T> FindByKeyAsync(params object[] key)
        {
            return await entities.FindAsync(key);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }
        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> expr = null)
        {
            return expr == null ? await entities.ToArrayAsync() : await entities.Where(expr).ToArrayAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await entities.AddAsync(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return entity;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expr = null)
        {
            return expr == null ? await entities.AnyAsync() : await entities.AnyAsync(expr);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expr = null)
        {
            return expr == null ? await entities.FirstOrDefaultAsync() : await entities.FirstOrDefaultAsync(expr);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> expr = null)
        {
            return expr == null ? await entities.CountAsync() : await entities.CountAsync(expr);
        }
        public void Update(T entity)
        {
            try
            {
                entities.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(T entity)
        {
            try
            {
                entities.Remove(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void AddRange(List<T> entity)
        {
            try
            {
                _context.AddRange(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateRange(List<T> entity)
        {
            try
            {
                _context.UpdateRange(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteRange(List<T> entity)
        {
            try
            {
                _context.RemoveRange(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
