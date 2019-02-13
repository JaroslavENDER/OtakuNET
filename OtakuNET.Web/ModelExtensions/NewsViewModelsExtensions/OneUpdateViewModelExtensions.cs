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
        public static OneUpdateViewModel Initialize(this OneUpdateViewModel model, TitleUpdate titleUpdate, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            model.Title = titleUpdate.Title.Name;
            model.TitleKey = titleUpdate.Title.Key;
            model.Tag = tagTranslator.ToTag(titleUpdate.Tag);
            model.TagInfo = titleUpdate.Tag;
            model.Timestamp = timestampFormatter.Format(titleUpdate.CreatedAt.GetValueOrDefault());
            model.ImageSrc = titleUpdate.Title.ImageSrc;
            model.Info = new List<DataListInformationViewModel>().Initialize(titleUpdate.Information);

            return model;
        }
    }
}
