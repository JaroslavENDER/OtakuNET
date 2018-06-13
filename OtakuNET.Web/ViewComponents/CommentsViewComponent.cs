using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtakuNET.Web.ModelExtensions.CommentsViewModelsExtensions;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.CommentsViewModels;
using System.Threading.Tasks;

namespace OtakuNET.Web.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> userManager;
        public CommentsViewComponent(UserManager<ApplicationUser> userManager)
            => this.userManager = userManager;

        public async Task<IViewComponentResult> InvokeAsync(string contentType, string contentKey)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var model = new CommentsComponentViewModel().Initialize(contentType, contentKey, user != null);
            return View(model);
        }
    }
}
