using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMessageService _messageService;

        public DefaultController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView("HeaderPartial");
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.Date = DateTime.Now;
                message.Status = true;
                _messageService.Add(message);
                return PartialView();
            }
            return PartialView(message);
        }
    }
}
