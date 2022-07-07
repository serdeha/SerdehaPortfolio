using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Data.Concrete.EntityFramework.Context;
using SerdehaPortfolio.Data.Concrete.EntityFramework.Repositories;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Data.Concrete.EntityFramework
{
    public class EfExperienceDal : GenericRepository<Experience, SerdehaPortfolioDbContext>, IExperienceDal
    {
    }
}
