using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Hizmetler";
            return View();
        }
        
    }
}
