using CarBook.Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;


namespace CarBook.WebUI.Controllers.AdminControllers
{
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SocialMediaList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/SocialMedias");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7059/api/SocialMedias/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMediaDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateMediaDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7059/api/SocialMedias", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7059/api/SocialMedias?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateMediaDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7059/api/SocialMedias", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
            return View();

        }
    }
}
