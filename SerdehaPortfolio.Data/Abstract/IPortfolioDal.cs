using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Data.Abstract
{
    public interface IPortfolioDal:IBaseDal<Portfolio>
    {
        List<Portfolio> GetLastFivePortfolio(int takeCount);
    }
}
