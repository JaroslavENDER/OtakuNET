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
        public static TitleViewModel Initialize(this TitleViewModel model, Animanga title, List<UserList> userLists, ITagTranslator tagTranslator)
        {
            model.Title = title.Title;
            model.ImageSrc = title.ImageSrc;
            model.StudioName = title.StudioName;
            model.StudioImageSrc = title.StudioImageSrc;
            model.Description = title.Description;
            model.UserListControls = new UserListsControlViewModel().Initialize(userLists, title);
            model.Information = new TitleInformationViewModel().Initialize(title.Information, tagTranslator.ToTag(title.Tag));
            model.Raiting = new RaitingViewModel().Initialize(title.Raiting);
            model.InUserLists = new TitleInUserListsViewModel().Initialize(/*title.UserLists*/);
            model.Links = title.Links.Select(link => new LinkViewModel().Initialize(link)).ToList();

            return model;
        }
    }
}
