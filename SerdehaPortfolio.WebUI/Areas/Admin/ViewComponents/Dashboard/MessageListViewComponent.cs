using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class MessageListViewComponent:ViewComponent
    {
        private readonly IUserMessageService _userMessageService;


        public MessageListViewComponent(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var usersWithMessage = await _userMessageService.GetAllAsync(null,x=>x.User!)!;
            return View(_userMessageService.GetAll());
        }
    }
}
