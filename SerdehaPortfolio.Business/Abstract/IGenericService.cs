using System.Linq.Expressions;

namespace SerdehaPortfolio.Business.Abstract
{
    public interface IGenericService<T> where  T:class,new()
    {
        T? GetById(int id);
        List<T>? GetAll(Expression<Func<T, bool>>? filter = null);

        Task<IList<T>>? GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetAsync(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[] includeProperties);
        T? GetFirst();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int GetCount(Expression<Func<T, bool>>? filter = null);
    }
}
