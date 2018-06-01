using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
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
            var updates = await dbContext.Updates.Include(u => u.Anime).OrderByDescending(u => u.Timestamp).ToListAsync();
            var model = new UpdatesComponentViewModel().Initialize(updates, tagTranslator, timestampFormatter);
            return View(model);
        }
    }
}
