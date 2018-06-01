using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.AnimangaViewModels;
using OtakuNET.Web.Models.ProfileViewModels;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class ProfileListPartialViewModelExtensions
    {
        public static ProfileListPartialViewModel Initialize(this ProfileListPartialViewModel model, UserAnimeList userAnimeList)
        {
            model.Initialize(userAnimeList as UserList);
            model.ControllerName = "Anime";
            model.Titles = userAnimeList.Anime.Select(a => new TitlePreviewViewModel().Initialize(a.Anime)).ToList();

            return model;
        }

        public static ProfileListPartialViewModel Initialize(this ProfileListPartialViewModel model, UserMangaList userMangaList)
        {
            model.Initialize(userMangaList as UserList);
            model.ControllerName = "Manga";
            model.Titles = userMangaList.Manga.Select(m => new TitlePreviewViewModel().Initialize(m.Manga)).ToList();

            return model;
        }

        private static ProfileListPartialViewModel Initialize(this ProfileListPartialViewModel model, UserList userList)
        {
            model.Key = userList.Key;
            model.Name = userList.Name;

            return model;
        }
    }
}
