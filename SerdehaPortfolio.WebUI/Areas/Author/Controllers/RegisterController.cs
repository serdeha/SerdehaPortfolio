using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Core.Extensions;
using SerdehaPortfolio.Entity.Concrete;
using SerdehaPortfolio.WebUI.Areas.Author.Models;

namespace SerdehaPortfolio.WebUI.Areas.Author.Controllers
{
    [Area("Author")]
    public class RegisterController : Controller
    {
        private readonly UserManager<AuthorUser> _userManager;

        public RegisterController(UserManager<AuthorUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                AuthorUser authorUser = new AuthorUser
                {
                    ImageUrl = userRegisterViewModel.ImageFile != null ? ImageHelperExtension.UploadImage(userRegisterViewModel.ImageFile, "userPictures") : "userPictures\\defaultUser.png",
                    FirstName = userRegisterViewModel.FirstName,
                    LastName = userRegisterViewModel.LastName,
                    UserName = userRegisterViewModel.UserName,
                    Email = userRegisterViewModel.Mail
                };

                var result = await _userManager.CreateAsync(authorUser, userRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new {area = "Author"});
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);   
                    }
                    return View(userRegisterViewModel);
                }
            }
            else
            {
                return View(userRegisterViewModel);
            }
        }
    }
}
