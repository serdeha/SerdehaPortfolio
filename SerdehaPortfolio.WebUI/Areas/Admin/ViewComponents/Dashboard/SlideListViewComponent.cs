using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class SlideListViewComponent:ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public SlideListViewComponent(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_portfolioService.GetAll());
        }
    }
}
