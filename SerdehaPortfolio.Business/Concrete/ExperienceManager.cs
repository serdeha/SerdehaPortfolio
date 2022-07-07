using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class ExperienceManager:IExperienceService
    {
        private readonly IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public Experience? GetById(int id)
        {
            return _experienceDal.GetById(x=>x.ExperienceId == id);
        }

        public List<Experience>? GetAll(Expression<Func<Experience, bool>>? filter = null)
        {
            return filter == null ? _experienceDal.GetAll() : _experienceDal.GetAll(filter);
        }

        public Task<IList<Experience>>? GetAllAsync(Expression<Func<Experience, bool>>? predicate = null, params Expression<Func<Experience, object>>[] includeProperties)
        {
            return _experienceDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<Experience> GetAsync(Expression<Func<Experience, bool>>? predicate, params Expression<Func<Experience, object>>[] includeProperties)
        {
            return _experienceDal.GetAsync(predicate, includeProperties);
        }

        public Experience? GetFirst()
        {
            return _experienceDal.GetFirst();
        }

        public void Add(Experience? entity)
        {
            if(entity != null)
                _experienceDal.Add(entity);
        }

        public void Update(Experience? entity)
        {
            if(entity != null)
                _experienceDal.Update(entity);
        }

        public void Delete(Experience? entity)
        {
            if(entity != null)
                _experienceDal.Delete(entity);
        }

        public int GetCount(Expression<Func<Experience, bool>>? filter = null)
        {
            return filter == null ? _experienceDal.GetCount() : _experienceDal.GetCount(filter);
        }
    }
}
