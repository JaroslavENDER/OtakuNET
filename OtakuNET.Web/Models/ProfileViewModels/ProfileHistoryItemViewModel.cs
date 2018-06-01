using OtakuNET.Web.Models.AnimangaViewModels;

namespace OtakuNET.Web.Models.ProfileViewModels
{
    public class ProfileHistoryItemViewModel
    {
        public TitlePreviewPartialViewModel TitleInfo { get; set; }
        public string Timestamp { get; set; }
        public string Text { get; set; }
        public UserListInfoViewModel UserList{ get; set; }
    }
}
