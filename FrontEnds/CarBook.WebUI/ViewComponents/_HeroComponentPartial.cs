using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents
{
    public class _HeroComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
