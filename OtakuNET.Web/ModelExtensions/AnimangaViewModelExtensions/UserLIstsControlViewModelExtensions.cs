using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.TitleViewModels;
using System.Collections.Generic;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class UserLIstsControlViewModelExtensions
    {
        /// <summary>
        /// Fake initializator
        /// </summary>
        public static UserListsControlViewModel Initialize(this UserListsControlViewModel model, IEnumerable<UserList> userLists, Title title)
        {
            return model;
        }
    }
}
