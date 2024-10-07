using CarBook.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/Locations");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.locationName,
                                                Value = x.locationId.ToString()
                                            }).ToList();
            ViewBag.LocationDrop = values2;

            return View();
        }
        [HttpPost]
        public IActionResult Index(string pick_date, string off_date, string time_pick , string time_off, string locationId)
        {
            TempData["pickdate"]=pick_date;
            TempData["offdate"]=off_date;
            TempData["timepick"]=time_pick;
            TempData["timeoff"]=time_off;
            TempData["location"]=locationId;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}
