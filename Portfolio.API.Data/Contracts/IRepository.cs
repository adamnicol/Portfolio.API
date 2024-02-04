using System.Linq.Expressions;

namespace Portfolio.API.Data.Contracts
{
    public interface IRepository<T> where T : IEntity
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id); 
        Task<T?> Find(Expression<Func<T, bool>> where);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
