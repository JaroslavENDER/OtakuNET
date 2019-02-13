using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Domain.Enums;
using OtakuNET.Web.ModelExtensions.CommentsViewModelsExtensions;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.CommentsViewModels;
using OtakuNET.Web.Services.CommentCreater;

namespace OtakuNET.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/comments")]
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

        [HttpGet("send/{contentType}/{contentKey}/{text}")]
        public async Task<CommentViewModel> Send(CommentSendViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");

            var profile = await dbContext.Profiles.FindAsync(user.Id);
            var comment = model.ContentType == "Titles"
                ? await CreateAnimangaComment(db => db.Titles.Where(t => t.Type == TitleType.Anime), profile, model)
                : model.ContentType == "Titles"
                    ? await CreateAnimangaComment(db => db.Titles.Where(t => t.Type == TitleType.Manga), profile, model)
                    : model.ContentType == "News"
                        ? await CreateNewsComment(profile, model)
                        : null;
            if (comment == null)
                throw new ArgumentException($"Invalid argument '{model.ContentType}'");

            profile.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
            return new CommentViewModel().Initialize(comment, timestampFormatter);
        }

        private async Task<Comment> CreateAnimangaComment<T>(Func<IDbContext, IQueryable<T>> func, Profile profile, CommentSendViewModel commentInfo) where T : Title
        {
            var animanga = await func(dbContext).FirstOrDefaultAsync(a => a.Key == commentInfo.ContentKey);
            return commentCreater.Create(profile, commentInfo, animanga);
        }

        private async Task<Comment> CreateNewsComment(Profile profile, CommentSendViewModel commentInfo)
        {
            var news = await dbContext.News.FindAsync(int.Parse(commentInfo.ContentKey));
            return commentCreater.Create(profile, commentInfo, news);
        }

        [HttpGet("get/{contentType}/{contentKey}")]
        public async Task<IEnumerable<CommentViewModel>> Get(string contentType, string contentKey)
        {
            var comments = contentType == "Titles"
                ? await GetAnimangaComments(db => db.Titles, contentKey)
                : contentType == "Titles"
                    ? await GetAnimangaComments(db => db.Titles, contentKey)
                    : contentType == "News"
                        ? await GetNewsComments(contentKey)
                        : throw new ArgumentException($"Invalid value '{contentType}'");

            return comments.Select(c => new CommentViewModel().Initialize(c, timestampFormatter)).ToList();
        }

        private async Task<IEnumerable<Comment>> GetAnimangaComments<T>(Func<IDbContext, IQueryable<T>> func, string key) where T : Title
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