using Microsoft.AspNetCore.Mvc;

namespace SerdehaPortfolio.WebUI.Areas.Author.Controllers
{
    [Area("Author")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
