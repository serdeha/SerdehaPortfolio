using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.ViewComponents.Feature
{
    public class FeatureViewComponent:ViewComponent
    {
        private readonly IFeatureService _featureService;

        public FeatureViewComponent(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IViewComponentResult Invoke()
        {
            var feature = _featureService.GetFirst();
            return View(feature);
        }
    }
}
