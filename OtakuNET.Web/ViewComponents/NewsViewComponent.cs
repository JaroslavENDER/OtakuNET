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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new NewsComponentViewModel
            {
                News = await dbContext.News
                .OrderByDescending(n => n.Timestamp)
                .Select(n => new OneNewsViewModel
                {
                    Title = n.Title,
                    Tag = Tag.News, //tagTranslator.ToTag(n.Tag),
                    //TagInfo = n.Tag,
                    Timestamp = timestampFormatter.Format(n.Timestamp),
                    ImageSrc = n.ImageSrc,
                    Text = n.Text
                })
                .ToListAsync()
            };
            return View(model);
        }
    }
}
