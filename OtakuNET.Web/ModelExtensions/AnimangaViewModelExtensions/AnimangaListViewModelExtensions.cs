using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.AnimangaViewModels;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class AnimangaListViewModelExtensions
    {
        public static AnimangaListViewModel Initialize(this AnimangaListViewModel model, IEnumerable<Title> titles, string actionName = "")
        {
            model.Header = actionName;
            model.Titles = titles.Select(t => new TitlePreviewViewModel().Initialize(t)).ToList();

            return model;
        }
    }
}
