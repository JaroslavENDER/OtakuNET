using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.ModelExtensions.HomeViewModelsExtentions;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.HomeViewModels;
using OtakuNET.Web.Services;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbContext dbContext;
        private readonly ITimestampFormatter timestampFormatter;
        private readonly ITagTranslator tagTranslator;
        public HomeController(IDbContext dbContext, ITagTranslator tagTranslator, ITimestampFormatter timestampFormatter)
        {
            this.dbContext = dbContext;
            this.tagTranslator = tagTranslator;
            this.timestampFormatter = timestampFormatter;
        }

        public async Task<IActionResult> Index()
        {
            var ongoings = await dbContext.Anime.Where(a => a.Tag == tagTranslator.ToString(Tag.Ongoing)).ToListAsync();
            var seasons = await dbContext.Seasons.ToListAsync();
            var news = await dbContext.News.ToListAsync();
            var updates = await dbContext.Updates.ToListAsync();
            var model = new IndexViewModel().Initialize(ongoings, null, null, seasons, news, updates, timestampFormatter, tagTranslator);

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
