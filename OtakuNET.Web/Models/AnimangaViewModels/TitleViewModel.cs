using System.Collections.Generic;

namespace OtakuNET.Web.Models.AnimangaViewModels
{
    public class TitleViewModel
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public UserListsControlViewModel UserListControls { get; set; }
        public TitleInformationViewModel Information { get; set; }
        public RaitingViewModel Raiting { get; set; }
        public string StudioName { get; set; }
        public string StudioImageSrc { get; set; }
        public string Description { get; set; }
        public TitleInUserListsViewModel InUserLists { get; set; }
        public List<LinkViewModel> Links { get; set; }
    }
}
