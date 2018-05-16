using Microsoft.AspNetCore.Mvc;

namespace OtakuNET.Web.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile(string login)
        {
            return View();
        }

        public IActionResult List(string loging, string name)
        {
            return View();
        }
    }
}