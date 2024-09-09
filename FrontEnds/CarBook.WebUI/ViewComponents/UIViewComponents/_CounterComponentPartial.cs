using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UIViewComponents
{
    public class _CounterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
