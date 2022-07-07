using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Business.ValidationRules;
using SerdehaPortfolio.Core.Extensions;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {
            ViewBag.FirstItem = "Deneyimlerim";
            return View(_experienceService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.FirstItem = "Deneyimlerim";
            ViewBag.SecondItem = "Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Experience experience)
        {
            if (ModelState.IsValid)
            {
                experience.ImageUrl ??= "defaultExperience.png";
                ExperienceValidator validator = new ExperienceValidator();
                ValidationResult result = validator.Validate(experience);
                if (result.IsValid)
                {
                    if(experience.FormFile != null) experience.ImageUrl = ImageHelperExtension.UploadImage(experience.FormFile, "experiences");
                    _experienceService.Add(experience);
                    return RedirectToAction("Index", "Experience");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    ViewBag.FirstItem = "Deneyimlerim";
                    ViewBag.SecondItem = "Ekle";
                    return View(experience);
                }
            }
            return View(experience);
        }

        [HttpGet]
        public IActionResult Delete(int experienceId)
        {
            var deletedExperience = _experienceService.GetById(experienceId);
            if (deletedExperience != null)
            {
                if (deletedExperience.ImageUrl != null && deletedExperience.ImageUrl != "defaultExperience.png") ImageHelperExtension.DeleteImage(deletedExperience.ImageUrl,"experiences");
                _experienceService.Delete(deletedExperience);
                return RedirectToAction("Index", "Experience");
            }
            return RedirectToAction("Index", "Experience");
        }
        
        [HttpGet]
        public IActionResult Update(int experienceId)
        {
            ViewBag.FirstItem = "Deneyimlerim";
            ViewBag.SecondItem = "Güncelle";
            var updatedExperience = _experienceService.GetById(experienceId);
            return View(updatedExperience);
        }

        [HttpPost]
        public IActionResult Update(Experience experience)
        {
            if (ModelState.IsValid)
            {
                ExperienceValidator validator = new ExperienceValidator();
                ValidationResult result = validator.Validate(experience);
                if (result.IsValid)
                {
                    if (experience.FormFile != null)
                    {
                        if (experience.ImageUrl != null && experience.ImageUrl != "defaultExperience.png") ImageHelperExtension.DeleteImage(experience.ImageUrl, "experiences");
                        experience.ImageUrl = ImageHelperExtension.UploadImage(experience.FormFile, "experiences");
                    }
                    _experienceService.Update(experience);
                    return RedirectToAction("Index", "Experience");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    ViewBag.FirstItem = "Deneyimlerim";
                    ViewBag.SecondItem = "Güncelle";
                    return View(experience);
                }
            }
            return View(experience);
        }
    }
}
