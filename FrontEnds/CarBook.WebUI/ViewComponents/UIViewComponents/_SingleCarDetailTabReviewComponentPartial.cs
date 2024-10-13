using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UIViewComponents
{
	public class _SingleCarDetailTabReviewComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
