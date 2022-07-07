using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Business.ValidationRules;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            ViewBag.FirstItem = "Yeteneklerim";
            return View(_skillService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.FirstItem = "Yeteneklerim";
            ViewBag.SecondItem = "Ekle";
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Skill skill)
        {
            if (ModelState.IsValid)
            {
                SkillValidator validator = new SkillValidator();
                ValidationResult result = validator.Validate(skill);
                if (result.IsValid)
                {
                    _skillService.Add(skill);
                    return RedirectToAction("Index", "Skill");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                    }

                    ViewBag.FirstItem = "Yeteneklerim";
                    ViewBag.SecondItem = "Ekle";
                    return View(skill);
                }
            }
            return View(skill);
        }

        [HttpGet]
        public IActionResult Delete(int skillId)
        {
            var skill = _skillService.GetById(skillId);
            if(skill != null)
            {
                _skillService.Delete(skill);
                return RedirectToAction("Index", "Skill");
            }
            return RedirectToAction("Index", "Skill");
        }

        [HttpGet]
        public IActionResult Update(int skillId)
        {
            var updatedSkill = _skillService.GetById(skillId);
            if(updatedSkill != null)
            {
                ViewBag.FirstItem = "Yeteneklerim";
                ViewBag.SecondItem = "Güncelle";
                return View(updatedSkill);
            }

            return RedirectToAction("Index", "Skill");
        }

        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            if (ModelState.IsValid)
            {
                SkillValidator validator = new SkillValidator();
                ValidationResult result = validator.Validate(skill);
                if (result.IsValid)
                {
                    _skillService.Update(skill);
                    return RedirectToAction("Index", "Skill");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    ViewBag.FirstItem = "Yeteneklerim";
                    ViewBag.SecondItem = "Güncelle";
                    return View(skill);
                }
            }

            return View(skill);
        }
    }
}
