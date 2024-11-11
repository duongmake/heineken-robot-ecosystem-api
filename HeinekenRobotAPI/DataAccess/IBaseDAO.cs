using System.Linq.Expressions;

namespace HeinekenRobotAPI.DataAccess
{
    public interface IBaseDAO<T, TKey> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        IQueryable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task Add(T entity);
        Task<bool> Remove(TKey id);
        Task Update(T entity);
        Task<T> GetByID(TKey id);
    }
}
