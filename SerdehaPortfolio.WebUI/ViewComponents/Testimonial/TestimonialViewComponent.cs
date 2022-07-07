using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.ViewComponents.Testimonial
{
    public class TestimonialViewComponent:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialViewComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var testimonialList = _testimonialService.GetAll();
            return View(testimonialList);
        }
    }
}
