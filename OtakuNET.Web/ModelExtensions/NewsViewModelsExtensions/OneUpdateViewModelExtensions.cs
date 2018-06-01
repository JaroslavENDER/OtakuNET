using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services.TagTranslator;
using System.Collections.Generic;

namespace OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions
{
    public static class OneUpdateViewModelExtensions
    {
        public static OneUpdateViewModel Initialize(this OneUpdateViewModel model, Update update, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            model.Title = update.Anime.Title;
            model.TitleKey = update.Anime.Key;
            model.Tag = tagTranslator.ToTag(update.Tag);
            model.TagInfo = update.Tag;
            model.Timestamp = timestampFormatter.Format(update.Timestamp);
            model.ImageSrc = update.Anime.ImageSrc;
            model.Info = new List<DataListInformationViewModel>().Initialize(update.Infomation);

            return model;
        }
    }
}
