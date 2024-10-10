using CarBook.Dtos.CarDtos;
using CarBook.Dtos.LocationDtos;
using CarBook.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
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
            List<SelectListItem> values3 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.locationName,
                                                Value = x.locationId.ToString()
                                            }).ToList();

            values2.Insert(0,new SelectListItem { Text = "Alınacak Lokasyonu Seçiniz", Value = "" });
            values3.Insert(0,new SelectListItem { Text = "İade Edilecek Lokasyonu Seçiniz", Value = "" });
            ViewBag.pickLocation = values2;
            ViewBag.dropLocation=values3;

            var carResponse = await client.GetAsync($"https://localhost:7059/api/Cars/{id}");
            var carJson = await carResponse.Content.ReadAsStringAsync();
            var carValue = JsonConvert.DeserializeObject<UpdateCarDto>(carJson);
            ViewBag.v2 = carValue.model;
            ViewBag.v3 = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7059/api/Reservations", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}
