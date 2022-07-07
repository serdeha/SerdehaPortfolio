using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class LastFiveProjectViewComponent:ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public LastFiveProjectViewComponent(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            var lastFiveProject = _portfolioService.GetLastFiveProjects(6);
            return View(lastFiveProject);
        }
    }
}
