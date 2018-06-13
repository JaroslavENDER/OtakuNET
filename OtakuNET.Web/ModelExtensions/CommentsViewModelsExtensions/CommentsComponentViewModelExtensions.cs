using OtakuNET.Web.Models.CommentsViewModels;

namespace OtakuNET.Web.ModelExtensions.CommentsViewModelsExtensions
{
    public static class CommentsComponentViewModelExtensions
    {
        public static CommentsComponentViewModel Initialize(this CommentsComponentViewModel model, string contentType, string contentKey, bool isUserSignIn)
        {
            model.ContentType = contentType;
            model.ContentKey = contentKey;
            model.IsUserSignIn = isUserSignIn;

            return model;
        }
    }
}
