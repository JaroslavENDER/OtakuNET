using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services;
using System.Collections.Generic;

namespace OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions
{
    public static class OneUpdateViewModelExtensions
    {
        public static OneUpdateViewModel Initialize(this OneUpdateViewModel model, Update update, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            return new OneUpdateViewModel
            {
                Title = update.Anime.Title,
                TitleKey = update.Anime.Key,
                Tag = tagTranslator.ToTag(update.Tag),
                TagInfo = update.Tag,
                Timestamp = timestampFormatter.Format(update.Timestamp),
                ImageSrc = update.Anime.ImageSrc,
                Info = new List<DataListInformationViewModel>().Initialize(update.Infomation)
            };
        }
    }
}
