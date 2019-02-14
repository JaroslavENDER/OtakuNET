using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.ProfileViewModels;
using System.Linq;
using OtakuNET.Domain.Enums;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class ProfileViewModelExtensions
    {
        public static ProfileViewModel Initialize(this ProfileViewModel model, Profile profile, ITimestampFormatter timestampFormatter)
        {
            model.Login = profile.Login;
            model.Name = profile.Name;
            model.AvatarId = profile.Avatar?.Id.ToString();
            model.RegirtrationDate = profile.History.Min(h => h.CreatedAt)?.ToLongDateString();
            model.UserAnimeLists = profile.UserLists.Where(ul => ul.Type == TitleType.Anime).Select(l => new UserListInfoViewModel().Initialize(l)).ToList();
            model.UserMangaLists = profile.UserLists.Where(ul => ul.Type == TitleType.Manga).Select(l => new UserListInfoViewModel().Initialize(l)).ToList();
            model.History = profile.History
                .OrderByDescending(h => h.CreatedAt)
                .Take(3)
                .Select(h => new ProfileHistoryItemViewModel().Initialize(h, timestampFormatter))
                .ToList();

            return model;
        }
    }
}
