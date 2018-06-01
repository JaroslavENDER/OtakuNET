using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services.TagTranslator;

namespace OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions
{
    public static class OneNewsViewModelExtensions
    {
        public static OneNewsViewModel Initialize(this OneNewsViewModel model, News news, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            model.Key = news.Id;
            model.Title = news.Title;
            model.Tag = tagTranslator.ToTag(news.Tag);
            model.TagInfo = news.Tag;
            model.Timestamp = timestampFormatter.Format(news.Timestamp);
            model.ImageSrc = news.ImageSrc;
            model.Text = news.Text;

            return model;
        }
    }
}
