using HeinekenRobotAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HeinekenRobotAPI.DataAccess
{
    public class BaseDAO<T, Tkey> : IBaseDAO<T, Tkey> where T : class
    {
        private readonly HeinekenRobotDBContext _context;
        private readonly DbSet<T> dbSet;
        public BaseDAO()
        {
            _context = new HeinekenRobotDBContext();
            dbSet = _context.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var result = dbSet.Where(where);

            foreach (var include in includes)
            {
                result = result.Include(include);
            }
            return result;
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual async Task<T> GetByID(Tkey id)
        {
            return await dbSet.FindAsync(id) ?? null;
        }

        public virtual async Task<T> GetByIDInclude(Tkey id, Expression<Func<T, object>> includeProperty = null)
        {
            IQueryable<T> query = dbSet.Where(x => EF.Property<Guid>(x, "CampaignId") == (Guid)(object)id);
            if (includeProperty != null)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<bool> Remove(Tkey id)
        {
            T? entity = await dbSet.FindAsync(id);
            if (entity == null || id == null)
            {
                return false;
            }
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
