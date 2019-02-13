using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.ProfileViewModels;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class UserListInfoViewModelExtensions
    {
        public static UserListInfoViewModel Initialize(this UserListInfoViewModel model, UserList userList)
        {
            model.Key = userList.Key;
            model.Name = userList.Name;
            model.Description = userList.Description;
            model.TitleCount = userList.TitleList.Count;

            return model;
        }
    }
}
