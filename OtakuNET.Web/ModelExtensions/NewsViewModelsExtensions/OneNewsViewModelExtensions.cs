using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;

namespace OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions
{
    public static class OneNewsViewModelExtensions
    {
        public static OneNewsViewModel Initialize(this OneNewsViewModel model, News news, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            return new OneNewsViewModel
            {
                Title = news.Title,
                Tag = tagTranslator.ToTag(news.Tag),
                TagInfo = news.Tag,
                Timestamp = timestampFormatter.Format(news.Timestamp),
                ImageSrc = news.ImageSrc,
                Text = news.Text
            };
        }
    }
}
