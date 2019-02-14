using System.Collections.Generic;

namespace OtakuNET.Web.Models.TitleViewModels
{
    public class TitleListViewModel
    {
        public string Header { get; set; }
        public List<TitlePreviewViewModel> Titles { get; set; }
    }
}
