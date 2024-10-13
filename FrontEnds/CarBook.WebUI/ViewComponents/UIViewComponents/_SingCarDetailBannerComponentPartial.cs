using CarBook.Dtos.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.UIViewComponents
{
	public class _SingCarDetailBannerComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _SingCarDetailBannerComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7059/api/Cars/GetCarWithBrandByCarId?id={id}");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCarWithBrandDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
