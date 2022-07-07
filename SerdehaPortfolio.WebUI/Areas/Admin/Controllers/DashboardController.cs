using Microsoft.AspNetCore.Mvc;

namespace SerdehaPortfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController:Controller
    {
        public IActionResult Index()
        {
            ViewBag.FirstItem = "Dashboard";
            return View();
        }
    }
}
