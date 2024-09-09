using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UIViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
