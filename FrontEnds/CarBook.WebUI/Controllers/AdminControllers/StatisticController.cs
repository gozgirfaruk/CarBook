using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers.AdminControllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
