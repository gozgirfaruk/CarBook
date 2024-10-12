using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UIViewComponents
{
    public class _SingleBlogLeaveCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
