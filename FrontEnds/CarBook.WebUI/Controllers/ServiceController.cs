﻿using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Hizmetler";
            return View();
        }
    }
}
