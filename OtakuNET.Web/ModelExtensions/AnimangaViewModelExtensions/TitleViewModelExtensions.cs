using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.TitleViewModels;
using OtakuNET.Web.Services.TagTranslator;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions
{
    public static class TitleViewModelExtensions
    {
        public static TitleViewModel Initialize(this TitleViewModel model, Title title, IEnumerable<UserList> userLists, ITagTranslator tagTranslator)
        {
            model.Initialize(title, tagTranslator);
            model.UserListControls = new UserListsControlViewModel().Initialize(userLists, title);

            return model;
        }

        private static TitleViewModel Initialize(this TitleViewModel model, Title title, ITagTranslator tagTranslator)
        {
            model.Key = title.Key;
            model.Title = title.Name;
            model.ImageSrc = title.ImageSrc;
            model.StudioName = title.StudioName;
            model.StudioImageSrc = title.StudioImageSrc;
            model.Description = title.Description;
            model.Information = new TitleInformationViewModel().Initialize(title.Information, tagTranslator.ToTag(title.Tag));
            model.Rating = new RatingViewModel().Initialize(title.Rating);
            model.InUserLists = new TitleInUserListsViewModel().Initialize(/*title.UserLists*/);
            model.Links = title.Links.Select(link => new LinkViewModel().Initialize(link)).ToList();

            return model;
        }
    }
}
