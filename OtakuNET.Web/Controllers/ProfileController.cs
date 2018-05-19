using Microsoft.AspNetCore.Mvc;

namespace OtakuNET.Web.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile(string login)
        {
            return View();
        }

        public IActionResult List(string login, string param)
        {
            return View();
        }

        public IActionResult History(string login, string param)
        {
            return View();
        }
    }
}