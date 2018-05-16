using Microsoft.AspNetCore.Mvc;

namespace OtakuNET.Web.Controllers
{
    public class StudioController : Controller
    {
        public IActionResult Name(string name)
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}