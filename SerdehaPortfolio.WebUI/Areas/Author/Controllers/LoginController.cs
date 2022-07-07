using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.WebUI.Areas.Author.Controllers
{
    [Area("Author")]
    public class LoginController : Controller
    {
        private readonly SignInManager<AuthorUser> _signInManager;

        public LoginController(SignInManager<AuthorUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
