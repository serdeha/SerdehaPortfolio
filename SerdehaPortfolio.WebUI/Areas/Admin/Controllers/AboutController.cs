using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Business.ValidationRules;
using SerdehaPortfolio.Core.Extensions;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FirstItem = "Hakkımda";
            ViewBag.SecondItem = "Güncelle";
            return View(_aboutService.GetFirst());
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            if (ModelState.IsValid)
            {
                AboutValidator validator = new AboutValidator();
                ValidationResult result = validator.Validate(about);
                if (result.IsValid)
                {
                    if (about.FormFile != null)
                    {
                        if (about.ImageUrl != null && about.ImageUrl != "defaultAbout.png") ImageHelperExtension.DeleteImage(about.ImageUrl, "about");
                        about.ImageUrl = ImageHelperExtension.UploadImage(about.FormFile, "about");
                    }
                    _aboutService.Update(about);
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                    }
                    ViewBag.FirstItem = "Hakkımda";
                    ViewBag.SecondItem = "Güncelle";
                    return View(about);
                }
            }

            return View(about);
        }
    }
}
