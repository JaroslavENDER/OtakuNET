using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.CommentsViewModels;

namespace OtakuNET.Web.ModelExtensions.CommentsViewModelsExtensions
{
    public static class CommentViewModelExtensions
    {
        public static CommentViewModel Initialize(this CommentViewModel model, Comment comment, ITimestampFormatter timestampFormatter)
        {
            model.ProfileAvatarId = comment.Profile.Avatar?.Id.ToString();
            model.ProfileLogin = comment.Profile.Login;
            model.Text = comment.Text;
            model.Timestamp = timestampFormatter.Format(comment.Timestamp);

            return model;
        }
    }
}
