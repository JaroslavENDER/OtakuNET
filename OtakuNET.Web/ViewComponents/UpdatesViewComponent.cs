using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.ViewComponents
{
    public class UpdatesViewComponent : ViewComponent
    {
        private readonly IDbContext dbContext;
        private readonly ITimestampFormatter timestampFormatter;
        private readonly ITagTranslator tagTranslator;
        public UpdatesViewComponent(IDbContext dbContext, ITimestampFormatter timestampFormatter, ITagTranslator tagTranslator)
        {
            this.dbContext = dbContext;
            this.timestampFormatter = timestampFormatter;
            this.tagTranslator = tagTranslator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new UpdatesComponentViewModel
            {
                Updates = await dbContext.Updates
                .OrderByDescending(u => u.Timestamp)
                .Select(u => new OneUpdateViewModel
                {
                    Title = u.Anime.Title,
                    Tag = tagTranslator.ToTag(u.Tag),
                    TagInfo = u.Tag,
                    Timestamp = timestampFormatter.Format(u.Timestamp),
                    ImageSrc = u.Anime.ImageSrc,
                    Info = u.Infomation
                    .GroupBy(info => info.Name)
                    .Select(group => new DataListInformationViewModel
                    {
                        Key = group.Key,
                        Values = group.Select(g => g.Value).ToList()
                    }).ToList()
                })
                .ToListAsync()
            };
            return View(model);
        }
    }
}
