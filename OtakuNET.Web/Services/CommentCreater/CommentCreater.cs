using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.CommentsViewModels;
using System;

namespace OtakuNET.Web.Services.CommentCreater
{
    public class CommentCreater : ICommentCreater
    {
        public Comment Create(Profile profile, CommentSendViewModel comment, Animanga animanga)
        {
            var result = Create(profile, comment.Text);
            result.Anime = animanga as Anime;
            result.Manga = animanga as Manga;

            return result;
        }

        public Comment Create(Profile profile, CommentSendViewModel comment, News news)
        {
            var result = Create(profile, comment.Text);
            result.News = news;

            return result;
        }

        private Comment Create(Profile profile, string text)
            => new Comment
            {
                Profile = profile,
                Timestamp = DateTime.Now,
                Text = text
            };
    }
}
