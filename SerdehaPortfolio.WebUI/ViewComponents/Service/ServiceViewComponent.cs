using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.ViewComponents.Service
{
    public class ServiceViewComponent:ViewComponent
    {
        private readonly IServiceService _serviceService;

        public ServiceViewComponent(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var serviceList = _serviceService.GetAll();
            return View(serviceList);
        }
    }
}
