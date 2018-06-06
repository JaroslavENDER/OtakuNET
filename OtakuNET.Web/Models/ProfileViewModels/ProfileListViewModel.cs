using System.Collections.Generic;

namespace OtakuNET.Web.Models.ProfileViewModels
{
    public class ProfileListViewModel
    {
        public string UserLogin { get; set; }
        public List<ProfileListPartialViewModel> Lists { get; set; }
    }
}
