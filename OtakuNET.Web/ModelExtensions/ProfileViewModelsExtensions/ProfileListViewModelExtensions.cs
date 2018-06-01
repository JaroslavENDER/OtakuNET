using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.ProfileViewModels;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class ProfileListViewModelExtensions
    {
        public static ProfileListViewModel Initialize(this ProfileListViewModel model, Profile profile, IEnumerable<UserList> userLists)
        {
            model.UserLogin = profile.Login;
            model.UserName = profile.Name;
            model.Lists = userLists
                .Select(l =>
                {
                    if (l is UserAnimeList) return new ProfileListPartialViewModel().Initialize(l as UserAnimeList);
                                        else return new ProfileListPartialViewModel().Initialize(l as UserMangaList);
                })
                .ToList();

            return model;
        }
    }
}
