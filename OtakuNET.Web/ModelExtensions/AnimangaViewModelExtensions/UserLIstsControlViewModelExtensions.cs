using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.AnimangaViewModels;
using System.Collections.Generic;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class UserLIstsControlViewModelExtensions
    {
        /// <summary>
        /// Fake initializator
        /// </summary>
        public static UserListsControlViewModel Initialize(this UserListsControlViewModel model, List<UserList> userLists, Animanga title)
        {
            return model;
        }
    }
}
