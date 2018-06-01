using OtakuNET.Web.Models.AnimangaViewModels;
using System;

namespace OtakuNET.Web.Models.ProfileViewModels
{
    public class ProfileHistoryItemViewModel
    {
        public TitlePreviewViewModel Title { get; set; }
        public string Timestamp { get; set; }
        public string Text { get; set; }
        public UserListInfoViewModel UserList{ get; set; }
    }
}
