using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class FeatureStatisticsViewComponent:ViewComponent
    {
        private readonly ISkillService _skillService;
        private readonly IMessageService _messageService;
        private readonly IExperienceService _experienceService;

        public FeatureStatisticsViewComponent(ISkillService skillService, IMessageService messageService, IExperienceService experienceService)
        {
            _skillService = skillService;
            _messageService = messageService;
            _experienceService = experienceService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SkillCount = _skillService.GetCount();
            ViewBag.MessageUnreadCount = _messageService.GetCount(x=>x.Status == false);
            ViewBag.MessageReadCount = _messageService.GetCount(x=>x.Status == true);
            ViewBag.ExperienceCount = _experienceService.GetCount();
            return View();
        }   
    }
}
