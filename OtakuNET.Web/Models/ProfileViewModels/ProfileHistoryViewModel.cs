using System.Collections.Generic;

namespace OtakuNET.Web.Models.ProfileViewModels
{
    public class ProfileHistoryViewModel
    {
        public string UserLogin { get; set; }
        public List<ProfileHistoryItemViewModel> HistoryItems { get; set; }
    }
}
