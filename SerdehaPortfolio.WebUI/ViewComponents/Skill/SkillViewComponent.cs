using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.ViewComponents.Skill
{
    public class SkillViewComponent:ViewComponent
    {
        private readonly ISkillService _skillService;

        public SkillViewComponent(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IViewComponentResult Invoke()
        {
            var skillList = _skillService.GetAll();
            return View(skillList);
        }
    }
}
