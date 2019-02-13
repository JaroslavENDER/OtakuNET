using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.CommentsViewModels;
using System;

namespace OtakuNET.Web.Services.CommentCreater
{
    public class CommentCreater : ICommentCreater
    {
        public Comment Create(Profile profile, CommentSendViewModel comment, Title title)
        {
            var result = Create(profile, comment.Text);
            result.Title = title;

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
                CreatedAt = DateTime.Now,
                Text = text
            };
    }
}
