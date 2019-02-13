using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.AnimangaViewModels;
using OtakuNET.Web.Models.ProfileViewModels;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class ProfileHistoryItemViewModelExtensions
    {
        public static ProfileHistoryItemViewModel Initialize(this ProfileHistoryItemViewModel model, ProfileHistoryItem historyItem, ITimestampFormatter timestampFormatter)
        {
            model.Text = historyItem.Text;
            model.Timestamp = timestampFormatter.Format(historyItem.CreatedAt.GetValueOrDefault());

            if (historyItem.Anime != null)
                model.TitleInfo = new TitlePreviewPartialViewModel
                {
                    ControllerName = "Anime",
                    Title = new TitlePreviewViewModel().Initialize(historyItem.Anime)
                };
            if (historyItem.Manga != null)
                model.TitleInfo = new TitlePreviewPartialViewModel
                {
                    ControllerName = "Manga",
                    Title = new TitlePreviewViewModel().Initialize(historyItem.Manga)
                };
            if (historyItem.UserList != null)
                model.UserList = new UserListInfoViewModel().Initialize(historyItem.UserList);

            return model;
        }
    }
}
