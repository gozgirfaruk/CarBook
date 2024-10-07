using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
     
        public IActionResult Index(string name)
        {
            ViewBag.Name = name;    
            return View();
        }
    }
}
