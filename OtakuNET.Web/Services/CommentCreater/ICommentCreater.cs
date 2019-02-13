using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.CommentsViewModels;

namespace OtakuNET.Web.Services.CommentCreater
{
    public interface ICommentCreater
    {
        Comment Create(Profile profile, CommentSendViewModel comment, Title title);
        Comment Create(Profile profile, CommentSendViewModel comment, News news);
    }
}
