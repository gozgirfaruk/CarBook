using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers.AdminControllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
