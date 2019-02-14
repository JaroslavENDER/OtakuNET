using OtakuNET.Web.Models.TitleViewModels;
using System.Collections.Generic;

namespace OtakuNET.Web.Models.ProfileViewModels
{
    public class ProfileListPartialViewModel
    {
        public string Key { get; set; }
        public string ControllerName { get; set; }
        public string Name { get; set; }
        public List<TitlePreviewViewModel> Titles { get; set; }
    }
}
