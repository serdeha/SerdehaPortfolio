using System.Linq.Expressions;
using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Data.Abstract
{
    public interface IBaseDal<T> where T:class,IEntity,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T>? GetAll(Expression<Func<T, bool>>? filter=null);
        Task<IList<T>>? GetAllAsync(Expression<Func<T,bool>>? predicate = null,params Expression<Func<T,object>>[] includeProperties);
        Task<T>? GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T? GetById(Expression<Func<T,bool>> filter);
        T? GetFirst();
        int GetCount(Expression<Func<T,bool>>? filter = null);
    }
}
