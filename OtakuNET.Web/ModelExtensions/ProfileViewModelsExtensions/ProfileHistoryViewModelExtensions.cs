using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.ProfileViewModels;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class ProfileHistoryViewModelExtensions
    {
        public static ProfileHistoryViewModel Initialize(this ProfileHistoryViewModel model, Profile profile, ITimestampFormatter timestampFormatter)
        {
            model.UserLogin = profile.Login;
            model.HistoryItems = profile.History
                .OrderByDescending(h => h.CreatedAt)
                .Select(h => new ProfileHistoryItemViewModel().Initialize(h, timestampFormatter))
                .ToList();

            return model;
        }
    }
}
