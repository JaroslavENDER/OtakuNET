using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.CommentsViewModels;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.CommentsViewModelsExtensions
{
    public static class CommentsComponentViewModelExtensions
    {
        public static CommentsComponentViewModel Initialize(this CommentsComponentViewModel model,
            IEnumerable<Comment> comments, string contentType, string contentKey, bool isUserSignIn, ITimestampFormatter timestampFormatter)
        {
            model.ContentType = contentType;
            model.ContentKey = contentKey;
            model.IsUserSignIn = isUserSignIn;
            model.Comments = comments.Select(c => new CommentViewModel().Initialize(c, timestampFormatter)).ToList();

            return model;
        }
    }
}
