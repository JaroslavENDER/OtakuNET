using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtakuNET.Web.Models;
using System.Threading.Tasks;

namespace OtakuNET.Web.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> userManager;
        public LoginViewComponent(UserManager<ApplicationUser> userManager)
            => this.userManager = userManager;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return View(user?.UserName as object);
        }
    }
}
