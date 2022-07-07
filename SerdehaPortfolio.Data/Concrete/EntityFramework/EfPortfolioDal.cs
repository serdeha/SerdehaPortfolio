using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Data.Concrete.EntityFramework.Context;
using SerdehaPortfolio.Data.Concrete.EntityFramework.Repositories;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Data.Concrete.EntityFramework
{
    public class EfPortfolioDal : GenericRepository<Portfolio, SerdehaPortfolioDbContext>,IPortfolioDal
    {
        public List<Portfolio> GetLastFivePortfolio(int takeCount)
        {
            using (var context = new SerdehaPortfolioDbContext())
            {
                if (context.Portfolios != null)
                    return context.Portfolios.OrderByDescending(x => x.PortfolioId).Take(takeCount).ToList();
                return new List<Portfolio>();
            }
        }
    }
}
