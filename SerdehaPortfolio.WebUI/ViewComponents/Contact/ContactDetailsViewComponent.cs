using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.ViewComponents.Contact
{
    public class ContactDetailsViewComponent:ViewComponent
    {
        private readonly IContactService _contactService;

        public ContactDetailsViewComponent(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var contact = _contactService.GetFirst();
            return View("~/Views/Shared/Components/Contact/ContactDetails/Default.cshtml",contact);
        }
    }
}
