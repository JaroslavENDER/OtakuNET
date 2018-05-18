using Microsoft.AspNetCore.Mvc;

namespace OtakuNET.Web.Controllers
{
    public class StudiosController : Controller
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