using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Business.ValidationRules;
using SerdehaPortfolio.Core.Extensions;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            ViewBag.FirstItem = "Projelerim";
            return View(_portfolioService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.FirstItem = "Projelerim";
            ViewBag.SecondItem = "Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                portfolio.ImageUrl ??= "defaultPortfolio.png";
                portfolio.ThumbnailImageUrl ??= "defaultPortfolioThumbnail.png";
                PortfolioValidator validator = new PortfolioValidator();
                ValidationResult result = validator.Validate(portfolio);
                if (result.IsValid)
                {
                    if (portfolio.ImageFormFile != null && portfolio.ThumbnailFormFile != null)
                    {
                        portfolio.ImageUrl = ImageHelperExtension.UploadImage(portfolio.ImageFormFile, "portfolios");
                        portfolio.ThumbnailImageUrl = ImageHelperExtension.UploadImage(portfolio.ThumbnailFormFile, "portfolios\\portfolioThumbnails");
                    }
                    _portfolioService.Add(portfolio);
                    return RedirectToAction("Index", "Portfolio");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    ViewBag.FirstItem = "Projelerim";
                    ViewBag.SecondItem = "Ekle";
                    return View(portfolio);
                }
            }
            return View(portfolio);
        }

        [HttpGet]
        public IActionResult Delete(int portfolioId)
        {
            var deletedPortfolio = _portfolioService.GetById(portfolioId);
            if (deletedPortfolio != null)
            {
                _portfolioService.Delete(deletedPortfolio);

                if (deletedPortfolio.ImageUrl != "defaultPortfolio.png" && deletedPortfolio.ImageUrl != null)
                    ImageHelperExtension.DeleteImage(deletedPortfolio.ImageUrl, "portfolios");

                if (deletedPortfolio.ThumbnailImageUrl != "defaultPortfolioThumbnail.png" && deletedPortfolio.ThumbnailImageUrl != null)
                    ImageHelperExtension.DeleteImage(deletedPortfolio.ThumbnailImageUrl, "portfolios\\portfolioThumbnails");

                return RedirectToAction("Index", "Portfolio");
            }
            return RedirectToAction("Index", "Portfolio");
        }

        [HttpGet]
        public IActionResult Update(int portfolioId)
        {
            ViewBag.FirstItem = "Projelerim";
            ViewBag.SecondItem = "Güncelle";
            var updatedPortfolio = _portfolioService.GetById(portfolioId);
            return View(updatedPortfolio);
        }

        [HttpPost]
        public IActionResult Update(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                PortfolioValidator validator = new PortfolioValidator();
                ValidationResult result = validator.Validate(portfolio);
                if (result.IsValid)
                {
                    if (portfolio.ImageFormFile != null)
                    {
                        if (portfolio.ImageUrl != null && portfolio.ImageUrl != "defaultPortfolio.png") ImageHelperExtension.DeleteImage(portfolio.ImageUrl, "portfolios");
                        portfolio.ImageUrl = ImageHelperExtension.UploadImage(portfolio.ImageFormFile, "portfolios");
                    }

                    if (portfolio.ThumbnailFormFile != null)
                    {
                        if (portfolio.ThumbnailImageUrl != null && portfolio.ThumbnailImageUrl != "defaultPortfolioThumbnail.png") ImageHelperExtension.DeleteImage(portfolio.ThumbnailImageUrl, "portfolios\\portfolioThumbnails");
                        portfolio.ThumbnailImageUrl = ImageHelperExtension.UploadImage(portfolio.ThumbnailFormFile, "portfolios\\portfolioThumbnails");
                    }

                    _portfolioService.Update(portfolio);
                    return RedirectToAction("Index", "Portfolio");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    ViewBag.FirstItem = "Projelerim";
                    ViewBag.SecondItem = "Güncelle";
                    return View(portfolio);
                }
            }

            return View(portfolio);
        }
    }
}
