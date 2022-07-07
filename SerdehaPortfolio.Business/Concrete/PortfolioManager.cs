using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class PortfolioManager:IPortfolioService
    {
        private readonly IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public Portfolio? GetById(int id)
        {
            return _portfolioDal.GetById(x => x.PortfolioId == id);
        }

        public List<Portfolio>? GetAll(Expression<Func<Portfolio, bool>>? filter = null)
        {
            return filter == null ? _portfolioDal.GetAll() : _portfolioDal.GetAll(filter);
        }

        public Task<IList<Portfolio>>? GetAllAsync(Expression<Func<Portfolio, bool>>? predicate = null, params Expression<Func<Portfolio, object>>[] includeProperties)
        {
            return _portfolioDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<Portfolio> GetAsync(Expression<Func<Portfolio, bool>>? predicate, params Expression<Func<Portfolio, object>>[] includeProperties)
        {
            return _portfolioDal.GetAsync(predicate, includeProperties);
        }

        public Portfolio? GetFirst()
        {
            return _portfolioDal.GetFirst();
        }

        public void Add(Portfolio? entity)
        {
            if(entity != null)
                _portfolioDal.Add(entity);
        }

        public void Update(Portfolio? entity)
        {
            if (entity != null)
                _portfolioDal.Update(entity);
        }

        public void Delete(Portfolio? entity)
        {
            if (entity != null)
                _portfolioDal.Delete(entity);
        }

        public int GetCount(Expression<Func<Portfolio, bool>>? filter = null)
        {
            return filter == null ? _portfolioDal.GetCount() : _portfolioDal.GetCount(filter);
        }

        public List<Portfolio> GetLastFiveProjects(int takeCount)
        {
            return _portfolioDal.GetLastFivePortfolio(takeCount);
            ;
        }
    }
}
