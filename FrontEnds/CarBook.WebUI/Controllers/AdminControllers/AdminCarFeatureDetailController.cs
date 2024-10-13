using CarBook.Dtos.CarFeatureDtos;
using CarBook.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers.AdminControllers
{
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7059/api/CarFeature?id={id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarFeatureByCarIdDto>>(jsonData);
                TempData["carId"] = id;
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<GetCarFeatureByCarIdDto> dto)
        {
            
            foreach (var item in dto)
            {
                item.CarId =(int)TempData["carId"];
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7059/api/CarFeature/CarFeatureChangeAvailableToTrue?id={item.FeatureId}");

                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7059/api/CarFeature/CarFeatureChangeAvailableToFalse?id={item.FeatureId}");
                }
            }
            return RedirectToAction("CarList", "Car");
        }

        public async Task<IActionResult> CreateFeatureByCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/Features");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);   
                return View(values);
            }
            return View();
        }
      
    }
}
