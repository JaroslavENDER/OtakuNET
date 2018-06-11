using System.Collections.Generic;

namespace OtakuNET.Web.Models.CommentsViewModels
{
    public class CommentsComponentViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public string ContentType { get; set; }
        public string ContentKey { get; set; }
        public bool IsUserSignIn { get; set; }
    }
}
