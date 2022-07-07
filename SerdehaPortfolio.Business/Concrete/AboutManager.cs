using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class AboutManager:IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About? GetById(int id)
        {
            return _aboutDal.GetById(x => x.AboutId == id);
        }

        public List<About>? GetAll(Expression<Func<About, bool>>? filter = null)
        {
            return filter == null ? _aboutDal.GetAll() : _aboutDal.GetAll(filter);
        }

        public Task<IList<About>>? GetAllAsync(Expression<Func<About, bool>>? predicate = null, params Expression<Func<About, object>>[] includeProperties)
        {
            return _aboutDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<About> GetAsync(Expression<Func<About, bool>>? predicate, params Expression<Func<About, object>>[] includeProperties)
        {
            return _aboutDal.GetAsync(predicate, includeProperties);
        }

        public About? GetFirst()
        {
            return _aboutDal.GetFirst();
        }

        public void Add(About? entity)
        {
            if (entity != null)
                _aboutDal.Add(entity);
        }

        public void Update(About? entity)
        {
            if (entity != null)
                _aboutDal.Update(entity);
        }

        public void Delete(About? entity)
        {
            if (entity != null)
                _aboutDal.Delete(entity);
        }

        public int GetCount(Expression<Func<About, bool>>? filter = null)
        {
            return filter == null ? _aboutDal.GetCount() : _aboutDal.GetCount(filter);
        }
    }
}
