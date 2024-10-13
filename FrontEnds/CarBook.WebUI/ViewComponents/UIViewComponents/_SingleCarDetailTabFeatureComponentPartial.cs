using CarBook.Dtos.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.UIViewComponents
{
	public class _SingleCarDetailTabFeatureComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _SingleCarDetailTabFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7059/api/CarFeature?id={id}");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();	
				var values = JsonConvert.DeserializeObject<List<GetCarFeatureByCarIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
