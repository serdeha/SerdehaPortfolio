using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class FeatureManager:IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public Feature? GetById(int id)
        {
            return _featureDal.GetById(x => x.FeatureId == id);
        }

        public List<Feature>? GetAll(Expression<Func<Feature, bool>>? filter = null)
        {
            return filter == null ? _featureDal.GetAll() : _featureDal.GetAll(filter);
        }

        public Task<IList<Feature>>? GetAllAsync(Expression<Func<Feature, bool>>? predicate = null, params Expression<Func<Feature, object>>[] includeProperties)
        {
            return _featureDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<Feature> GetAsync(Expression<Func<Feature, bool>>? predicate, params Expression<Func<Feature, object>>[] includeProperties)
        {
            return _featureDal.GetAsync(predicate, includeProperties);
        }

        public Feature? GetFirst()
        {
            return _featureDal.GetFirst();
        }

        public void Add(Feature? entity)
        {
            if(entity!=null)
                _featureDal.Add(entity);
        }

        public void Update(Feature? entity)
        {
            if(entity!=null)
                _featureDal.Update(entity);
        }

        public void Delete(Feature? entity)
        {
            if(entity!=null)
                _featureDal.Delete(entity);
        }

        public int GetCount(Expression<Func<Feature, bool>>? filter = null)
        {
            return filter == null ? _featureDal.GetCount() : _featureDal.GetCount(filter);
        }
    }
}
