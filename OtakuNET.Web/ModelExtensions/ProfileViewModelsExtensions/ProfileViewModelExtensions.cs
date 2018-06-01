﻿using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.ProfileViewModels;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions
{
    public static class ProfileViewModelExtensions
    {
        public static ProfileViewModel Initialize(this ProfileViewModel model, Profile profile, ITimestampFormatter timestampFormatter)
        {
            model.Login = profile.Login;
            model.Name = profile.Name;
            model.AvatarSrc = profile.AvatarSrc;
            model.UserAnimeLists = profile.AnimeListSet.Select(l => new UserListInfoViewModel().Initialize(l)).ToList();
            model.UserMangaLists = profile.MangaListSet.Select(l => new UserListInfoViewModel().Initialize(l)).ToList();
            model.History = profile.History.Select(h => new ProfileHistoryItemViewModel().Initialize(h, timestampFormatter)).ToList();

            return model;
        }
    }
}
