using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions
{
    public static class NewsComponentViewModelExtensions
    {
        public static NewsComponentViewModel Initialize(this NewsComponentViewModel model, List<News> news, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            return new NewsComponentViewModel
            {
                News = news.Select(n => new OneNewsViewModel().Initialize(n, tagTranslator, timestampFormatter)).ToList()
            };
        }
    }
}
