using CarBook.Dtos.BrandDtos;
using CarBook.Dtos.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers.AdminControllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CarList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/Cars/CarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7059/api/Cars?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brand = (from item in values
                                    select new SelectListItem
                                    {
                                        Text = item.name,
                                        Value = item.brandId.ToString()
                                    }).ToList();
            ViewBag.BrandList= brand;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7059/api/Cars", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7059/api/Cars/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var brandResponse = await client.GetAsync("https://localhost:7059/api/Brands");
                var jsonBrand = await brandResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonBrand);

                ViewBag.BrandList = new SelectList(result, "brandId", "name");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7059/api/Cars", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CarList");
            }
            return View();
        }
    }
}
