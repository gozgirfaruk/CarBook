using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardChartOneComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
