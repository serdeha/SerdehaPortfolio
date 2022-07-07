using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.ViewComponents.Portfolio
{
    public class PortfolioViewComponent:ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioViewComponent(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            var portfolioList = _portfolioService.GetAll();
            return View(portfolioList);
        }
    }
}
