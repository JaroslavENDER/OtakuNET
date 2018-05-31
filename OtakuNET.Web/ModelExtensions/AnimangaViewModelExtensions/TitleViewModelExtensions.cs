using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.AnimangaViewModels;
using OtakuNET.Web.Services;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class TitleViewModelExtensions
    {
        public static TitleViewModel Initialize(this TitleViewModel model, Animanga title, IEnumerable<UserAnimeList> userLists, ITagTranslator tagTranslator)
        {
            model.Initialize(title, tagTranslator);
            model.UserListControls = new UserListsControlViewModel().Initialize(userLists, title);

            return model;
        }

        public static TitleViewModel Initialize(this TitleViewModel model, Animanga title, IEnumerable<UserMangaList> userLists, ITagTranslator tagTranslator)
        {
            model.Initialize(title, tagTranslator);
            model.UserListControls = new UserListsControlViewModel().Initialize(userLists, title);

            return model;
        }

        private static TitleViewModel Initialize(this TitleViewModel model, Animanga title, ITagTranslator tagTranslator)
        {
            model.Title = title.Title;
            model.ImageSrc = title.ImageSrc;
            model.StudioName = title.StudioName;
            model.StudioImageSrc = title.StudioImageSrc;
            model.Description = title.Description;
            model.Information = new TitleInformationViewModel().Initialize(title.Information, tagTranslator.ToTag(title.Tag));
            model.Raiting = new RaitingViewModel().Initialize(title.Raiting);
            model.InUserLists = new TitleInUserListsViewModel().Initialize(/*title.UserLists*/);
            model.Links = title.Links.Select(link => new LinkViewModel().Initialize(link)).ToList();

            return model;
        }
    }
}
