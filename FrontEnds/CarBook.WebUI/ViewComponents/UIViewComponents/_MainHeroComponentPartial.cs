using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UIViewComponents
{
    public class _MainHeroComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
