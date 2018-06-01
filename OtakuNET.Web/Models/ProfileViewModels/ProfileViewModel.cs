using System.Collections.Generic;

namespace OtakuNET.Web.Models.ProfileViewModels
{
    public class ProfileViewModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string AvatarSrc { get; set; }
        public string RegirtrationDate { get; set; }
        public List<UserListInfoViewModel> UserAnimeLists { get; set; }
        public List<UserListInfoViewModel> UserMangaLists { get; set; }
        public List<ProfileHistoryItemViewModel> History { get; set; }
    }
}
