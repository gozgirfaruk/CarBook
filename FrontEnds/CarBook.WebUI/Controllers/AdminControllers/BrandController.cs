using CarBook.Dtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers.AdminControllers
{
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BrandList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/Brands");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7059/api/Brands/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatseBrand(UpdateBrandDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7059/api/Brands", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BrandList");
            }
            return View();  
        }
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7059/api/Brands?id={id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BrandList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7059/api/Brands", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BrandList");
            }
            return View();

        }
    }
}
