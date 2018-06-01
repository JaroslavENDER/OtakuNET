using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.ModelExtensions.NewsViewModelsExtensions;
using OtakuNET.Web.Models.NewsViewModels;
using OtakuNET.Web.Services.TagTranslator;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly IDbContext dbContext;
        private readonly ITagTranslator tagTranslator;
        private readonly ITimestampFormatter timestampFormatter;
        public NewsController(IDbContext dbContext, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            this.dbContext = dbContext;
            this.tagTranslator = tagTranslator;
            this.timestampFormatter = timestampFormatter;
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Updates()
        {
            return View();
        }

        public async Task<IActionResult> One(int? key)
        {
            if (!key.HasValue) return NotFound();
            var news = await dbContext.News.FirstOrDefaultAsync(n => n.Id == key);
            if (news == null) return NotFound();
            var model = new NewsOneViewModel().Initialize(news, tagTranslator, timestampFormatter);
            return View(model);
        }
    }
}