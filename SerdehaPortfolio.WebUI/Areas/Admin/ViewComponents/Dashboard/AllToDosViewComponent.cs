using Microsoft.AspNetCore.Mvc;
using SerdehaPortfolio.Business.Abstract;

namespace SerdehaPortfolio.WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class AllToDosViewComponent:ViewComponent
    {
        private readonly IToDoListService _todoListService;

        public AllToDosViewComponent(IToDoListService todoListService)
        {
            _todoListService = todoListService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_todoListService.GetAll());
        }
    }
}
