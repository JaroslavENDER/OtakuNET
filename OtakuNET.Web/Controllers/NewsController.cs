using Microsoft.AspNetCore.Mvc;

namespace OtakuNET.Web.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult News()
        {
            return View();
        }

        public IActionResult Updates()
        {
            return View();
        }
    }
}