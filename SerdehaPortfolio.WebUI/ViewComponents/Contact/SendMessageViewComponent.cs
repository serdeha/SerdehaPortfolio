using Microsoft.AspNetCore.Mvc;

namespace SerdehaPortfolio.WebUI.ViewComponents.Contact
{
    public class SendMessageViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/Contact/SendMessage/Default.cshtml");
        }
    }
}
