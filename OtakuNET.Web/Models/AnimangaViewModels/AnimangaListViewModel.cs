using System.Collections.Generic;

namespace OtakuNET.Web.Models.AnimangaViewModels
{
    public class AnimangaListViewModel
    {
        public string Header { get; set; }
        public List<TitlePreviewViewModel> Titles { get; set; }
    }
}
