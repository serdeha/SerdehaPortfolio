using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Business.ValidationRules;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FirstItem = "Sunum";
            ViewBag.SecondItem = "Güncelle";
            return View(_featureService.GetFirst());
        }

        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            if (ModelState.IsValid)
            {
                FeatureValidator validator = new FeatureValidator();
                ValidationResult result = validator.Validate(feature);
                if (result.IsValid)
                {
                    _featureService.Update(feature);
                    return RedirectToAction("Index","Feature");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    ViewBag.FirstItem = "Sunum";
                    ViewBag.SecondItem = "Güncelle";
                    return View(feature);
                }
            }

            return View(feature);
        }
    }
}
