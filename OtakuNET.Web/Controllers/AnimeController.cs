using Microsoft.AspNetCore.Mvc;

namespace OtakuNET.Web.Controllers
{
    public class AnimeController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}