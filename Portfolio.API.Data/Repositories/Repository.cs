using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data.Contracts;
using System.Linq.Expressions;

namespace Portfolio.API.Data.Repositories
{
    public abstract class Repository<T>(DataContext context) : IRepository<T> where T : class, IEntity
    {
        private DbSet<T> _dbSet = context.Set<T>();

        public virtual Task<List<T>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public virtual Task<T?> GetById(int id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual Task<T?> Find(Expression<Func<T, bool>> where)
        {
            return _dbSet.FirstOrDefaultAsync(where);
        }

        public virtual Task Add(T entity)
        {
            _dbSet.Add(entity);

            return context.SaveChangesAsync();

        }
        public virtual Task Update(T entity)
        {
            _dbSet.Update(entity);

            return context.SaveChangesAsync();
        }

        public virtual Task Delete(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);

            return context.SaveChangesAsync();
        }
    }
}
