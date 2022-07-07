using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Abstract
{
    public interface IPortfolioService:IGenericService<Portfolio>
    {
        List<Portfolio> GetLastFiveProjects(int takeCount);
    }
}
