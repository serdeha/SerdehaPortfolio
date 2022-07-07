using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Business.ValidationRules;
using SerdehaPortfolio.Core.Extensions;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            ViewBag.FirstItem = "Hizmetlerim";
            return View(_serviceService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.FirstItem = "Hizmetlerim";
            ViewBag.SecondItem = "Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Service service)
        {
            if (ModelState.IsValid)
            {
                service.ImageUrl ??= "defaultService.png";
                ServiceValidator validator = new ServiceValidator();
                ValidationResult result = validator.Validate(service);
                if (result.IsValid)
                {
                    if(service.FormFile != null) service.ImageUrl = ImageHelperExtension.UploadImage(service.FormFile, "services");
                    _serviceService.Add(service);
                    return RedirectToAction("Index","Service");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName,error.ErrorMessage);   
                    }
                    ViewBag.FirstItem = "Hizmetlerim";
                    ViewBag.SecondItem = "Ekle";
                    return View(service);
                }
            }
            return View(service);
        }

        [HttpGet]
        public IActionResult Delete(int serviceId)
        {
            var deletedService = _serviceService.GetById(serviceId);
            if (deletedService != null)
            {
                if (deletedService.ImageUrl != null && deletedService.ImageUrl != "defaultService.png")
                    ImageHelperExtension.DeleteImage(deletedService.ImageUrl, "services");
                
                _serviceService.Delete(deletedService);
            }

            return RedirectToAction("Index", "Service");
        }

        [HttpGet]
        public IActionResult Update(int serviceId)
        {
            ViewBag.FirstItem = "Hizmetlerim";
            ViewBag.SecondItem = "Güncelle";
            return View(_serviceService.GetById(serviceId));
        }

        [HttpPost]
        public IActionResult Update(Service service)
        {
            if (ModelState.IsValid)
            {
                ServiceValidator validator = new ServiceValidator();
                ValidationResult result = validator.Validate(service);
                if (result.IsValid)
                {
                    if(service.FormFile != null)
                    {
                        if (service.ImageUrl != null && service.ImageUrl != "defaultService.png") ImageHelperExtension.DeleteImage(service.ImageUrl, "services");
                        service.ImageUrl = ImageHelperExtension.UploadImage(service.FormFile, "services");
                    }
                    _serviceService.Update(service);
                    return RedirectToAction("Index", "Service");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                    }
                    ViewBag.FirstItem = "Hizmetlerim";
                    ViewBag.SecondItem = "Güncelle";
                    return View(service);
                }
            }

            return RedirectToAction("Index", "Service");
        }        
    }
}
