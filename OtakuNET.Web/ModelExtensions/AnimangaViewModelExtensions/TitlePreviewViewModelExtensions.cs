using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.AnimangaViewModels;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class TitlePreviewViewModelExtensions
    {
        public static TitlePreviewViewModel Initialize(this TitlePreviewViewModel model, Title title)
        {
            model.Key = title.Key;
            model.Name = title.Name;
            model.ImageSrc = title.ImageSrc;
            model.Info = title.StudioName;

            return model;
        }
    }
}
