using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions
{
    public static class OneUpdateViewModelExtensions
    {
        public static OneUpdateViewModel Initialize(this OneUpdateViewModel model, Update update, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            return new OneUpdateViewModel
            {
                Title = update.Anime.Title,
                Tag = tagTranslator.ToTag(update.Tag),
                TagInfo = update.Tag,
                Timestamp = timestampFormatter.Format(update.Timestamp),
                ImageSrc = update.Anime.ImageSrc,
                Info = update.Infomation
                    .GroupBy(info => info.Name)
                    .Select(group => new DataListInformationViewModel
                    {
                        Key = group.Key,
                        Values = group.Select(g => g.Value).ToList()
                    }).ToList()
            };
        }
    }
}
