using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.ViewComponents.Experience
{
    public class ExperienceViewComponent : ViewComponent
    {
        private readonly IExperienceService _experienceService;

        public ExperienceViewComponent(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IViewComponentResult Invoke()
        {
            var experienceList = _experienceService.GetAll();
            return View(experienceList);
        }
    }
}
