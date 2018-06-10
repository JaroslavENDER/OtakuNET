using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.CommentsViewModelsExtensions;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.CommentsViewModels;
using OtakuNET.Web.Services.CommentCreater;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICommentCreater commentCreater;
        private readonly ITimestampFormatter timestampFormatter;
        public CommentsController(IDbContext dbContext, UserManager<ApplicationUser> userManager, ICommentCreater commentCreater, ITimestampFormatter timestampFormatter)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.commentCreater = commentCreater;
            this.timestampFormatter = timestampFormatter;
        }

        public async Task<PartialViewResult> Send(CommentSendViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");

            var profile = await dbContext.Profiles.FindAsync(user.Id);
            var comment = model.ContentType == "Anime"
                ? await CreateAnimangaComment(db => db.Anime, profile, model)
                : model.ContentType == "Manga"
                    ? await CreateAnimangaComment(db => db.Manga, profile, model)
                    : model.ContentType == "News"
                        ? await CreateNewsComment(profile, model)
                        : null;
            if (comment == null)
                throw new ArgumentException($"Invalid argument '{model.ContentType}'");

            profile.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
            var returnedModel = new CommentViewModel().Initialize(comment, timestampFormatter);

            return PartialView("/Views/CommentsPartial/_CommentPartial.cshtml", returnedModel);
        }

        private async Task<Comment> CreateAnimangaComment<T>(Func<IDbContext, IQueryable<T>> func, Profile profile, CommentSendViewModel commentInfo) where T : Animanga
        {
            var animanga = await func(dbContext).FirstOrDefaultAsync(a => a.Key == commentInfo.ContentKey);
            return commentCreater.Create(profile, commentInfo, animanga);
        }
        
        private async Task<Comment> CreateNewsComment(Profile profile, CommentSendViewModel commentInfo)
        {
            var news = await dbContext.News.FindAsync(int.Parse(commentInfo.ContentKey));
            return commentCreater.Create(profile, commentInfo, news);
        }
    }
}
