using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.CommentsViewModelsExtensions;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.CommentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly IDbContext dbContext;
        private readonly ITimestampFormatter timestampFormatter;
        private readonly UserManager<ApplicationUser> userManager;
        public CommentsViewComponent(IDbContext dbContext, UserManager<ApplicationUser> userManager, ITimestampFormatter timestampFormatter)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.timestampFormatter = timestampFormatter;
        }

        public async Task<IViewComponentResult> InvokeAsync(string controllerName, string key)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var comments = controllerName == "Anime"
                ? await GetAnimangaComments(db => db.Anime, key)
                : controllerName == "Manga"
                    ? await GetAnimangaComments(db => db.Manga, key)
                    : controllerName == "News"
                        ? await GetNewsComments(key)
                        : throw new ArgumentException($"Invalid value '{controllerName}'");

            var model = new CommentsComponentViewModel().Initialize(comments, controllerName, key, user != null, timestampFormatter);
            return View(model);
        }

        private async Task<IEnumerable<Comment>> GetAnimangaComments<T>(Func<IDbContext, IQueryable<T>> func, string key) where T : Animanga
        {
            var animanga = await func(dbContext).Include(a => a.Comments).ThenInclude(c => c.Profile).ThenInclude(p => p.Avatar).FirstOrDefaultAsync(a => a.Key == key);
            return animanga.Comments;
        }

        private async Task<IEnumerable<Comment>> GetNewsComments(string key)
        {
            var news = await dbContext.News.Include(a => a.Comments).ThenInclude(c => c.Profile).ThenInclude(p => p.Avatar).FirstOrDefaultAsync(a => a.Id.ToString() == key);
            return news.Comments;
        }
    }
}
