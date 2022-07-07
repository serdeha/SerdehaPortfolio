using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Data.Concrete.EntityFramework.Repositories
{
    public class GenericRepository<TEntity, TContext> : IBaseDal<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                if (includeProperties.Any())
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                query = query.Where(predicate);

                if (includeProperties.Any())
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return await query.AsNoTracking().SingleOrDefaultAsync();
            }
        }

        public TEntity? GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).SingleOrDefault();
            }
        }

        public TEntity? GetFirst()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault();
            }
        }

        public int GetCount(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().Count() : context.Set<TEntity>().Where(filter).Count();
            }
        }
    }
}