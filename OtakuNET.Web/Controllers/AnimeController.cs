﻿using Microsoft.AspNetCore.Mvc;

namespace OtakuNET.Web.Controllers
{
    public class AnimeController : Controller
    {
        public IActionResult Title(int id)
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Season(string season)
        {
            return View();
        }
    }
}