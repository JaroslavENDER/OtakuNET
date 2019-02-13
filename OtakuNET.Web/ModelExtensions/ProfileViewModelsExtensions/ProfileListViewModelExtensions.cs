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
            model.Lists = userLists
                .Select(l => new ProfileListPartialViewModel().Initialize(l))
                .ToList();

            return model;
        }
    }
}
