using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services.TagTranslator;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.ViewComponents
{
    public class NewsViewComponent : ViewComponent
    {
        private readonly IDbContext dbContext;
        private readonly ITimestampFormatter timestampFormatter;
        private readonly ITagTranslator tagTranslator;
        public NewsViewComponent(IDbContext dbContext, ITimestampFormatter timestampFormatter, ITagTranslator tagTranslator)
        {
            this.dbContext = dbContext;
            this.timestampFormatter = timestampFormatter;
            this.tagTranslator = tagTranslator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count = 20)
        {
            var news = await dbContext.News
                .OrderByDescending(n => n.Timestamp)
                .Take(count)
                .ToListAsync();
            var model = new NewsComponentViewModel().Initialize(news, tagTranslator, timestampFormatter);
            return View(model);
        }
    }
}
