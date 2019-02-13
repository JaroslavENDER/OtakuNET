using Ender.TimestampFormatterCore;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions
{
    public static class UpdatesComponentViewModelExtensions
    {
        public static UpdatesComponentViewModel Initialize(this UpdatesComponentViewModel model, List<TitleUpdate> updates, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            return new UpdatesComponentViewModel
            {
                Updates = updates.Select(u => new OneUpdateViewModel().Initialize(u, tagTranslator, timestampFormatter)).ToList()
            };
        }
    }
}
