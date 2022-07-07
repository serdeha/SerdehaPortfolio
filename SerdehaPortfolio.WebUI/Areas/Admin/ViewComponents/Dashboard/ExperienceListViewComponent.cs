using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class ExperienceListViewComponent:ViewComponent
    {
        private readonly IExperienceService _experienceService;

        public ExperienceListViewComponent(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_experienceService.GetAll()?.OrderByDescending(X => X.ExperienceId).Take(5).ToList());
        }
    }
}
