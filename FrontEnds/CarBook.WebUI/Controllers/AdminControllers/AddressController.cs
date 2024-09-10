using CarBook.Dtos.AddressDtos;
using CarBook.Dtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Text;

namespace CarBook.WebUI.Controllers.AdminControllers
{
    public class AddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAddress(int id=1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7059/api/Addresses/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAddressDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7059/api/Addresses", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("UpdateAddress");
            }
            return View();
        }
    }
}
