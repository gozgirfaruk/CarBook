using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
