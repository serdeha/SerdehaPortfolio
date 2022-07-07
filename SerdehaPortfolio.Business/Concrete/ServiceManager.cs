using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class ServiceManager:IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public Service? GetById(int id)
        {
            return _serviceDal.GetById(x => x.ServiceId == id);
        }

        public List<Service>? GetAll(Expression<Func<Service, bool>>? filter = null)
        {
            return filter == null ? _serviceDal.GetAll() : _serviceDal.GetAll(filter);
        }

        public Task<IList<Service>>? GetAllAsync(Expression<Func<Service, bool>>? predicate = null, params Expression<Func<Service, object>>[] includeProperties)
        {
            return _serviceDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<Service> GetAsync(Expression<Func<Service, bool>>? predicate, params Expression<Func<Service, object>>[] includeProperties)
        {
            return _serviceDal.GetAsync(predicate, includeProperties);
        }

        public Service? GetFirst()
        {
            return _serviceDal.GetFirst();
        }

        public void Add(Service? entity)
        {
            if (entity != null)
                _serviceDal.Add(entity);
        }

        public void Update(Service? entity)
        {
            if (entity != null)
                _serviceDal.Update(entity);
        }

        public void Delete(Service? entity)
        {
            if (entity != null)
                _serviceDal.Delete(entity);
        }

        public int GetCount(Expression<Func<Service, bool>>? filter = null)
        {
            return filter == null ? _serviceDal.GetCount() : _serviceDal.GetCount(filter);
        }
    }
}
