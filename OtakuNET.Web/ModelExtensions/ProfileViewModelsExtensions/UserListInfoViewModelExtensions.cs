using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.ProfileViewModels;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class UserListInfoViewModelExtensions
    {
        public static UserListInfoViewModel Initialize(this UserListInfoViewModel model, UserAnimeList userList)
        {
            model.Initialize(userList as UserList);
            model.TitleCount = userList.Anime.Count;

            return model;
        }

        public static UserListInfoViewModel Initialize(this UserListInfoViewModel model, UserMangaList userList)
        {
            model.Initialize(userList as UserList);
            model.TitleCount = userList.Manga.Count;

            return model;
        }

        private static UserListInfoViewModel Initialize(this UserListInfoViewModel model, UserList userList)
        {
            model.Key = userList.Key;
            model.Name = userList.Name;
            model.Description = userList.Description;

            return model;
        }
    }
}
