using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.TitleViewModels;
using OtakuNET.Web.Models.ProfileViewModels;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class ProfileListPartialViewModelExtensions
    {
        public static ProfileListPartialViewModel Initialize(this ProfileListPartialViewModel model, UserList userList)
        {
            model.ControllerName = "Anime";
            model.Key = userList.Key;
            model.Name = userList.Name;
            model.Titles = userList.TitleList.Select(a => new TitlePreviewViewModel().Initialize(a.Title)).ToList();

            return model;
        }
    }
}
