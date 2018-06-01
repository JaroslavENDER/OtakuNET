using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services.TagTranslator;

namespace OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions
{
    public static class NewsOneViewModelExtensions
    {
        public static NewsOneViewModel Initialize(this NewsOneViewModel model, News news, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            model.News = new OneNewsViewModel().Initialize(news, tagTranslator, timestampFormatter);

            return model;
        }
    }
}
