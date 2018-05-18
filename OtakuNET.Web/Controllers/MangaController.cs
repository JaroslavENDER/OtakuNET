using Microsoft.AspNetCore.Mvc;

namespace OtakuNET.Web.Controllers
{
    public class MangaController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Title()
        {
            return View();
        }
    }
}