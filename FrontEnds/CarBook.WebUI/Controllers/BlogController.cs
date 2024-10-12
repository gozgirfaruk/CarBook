using CarBook.Dtos.BlogDtos;
using CarBook.Dtos.CommentDtos;
using CarBook.WebUI.ViewComponents.UIViewComponents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BlogList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/Blogs/GetBlogWithAuhtor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult BlogSingle(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LeaveComment(LeaveCommentDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            dto.createdDate = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7059/api/Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogList");
            }
            else
            {
                return View();
            }
        }
     
    }
}
