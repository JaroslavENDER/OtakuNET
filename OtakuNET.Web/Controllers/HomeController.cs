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
        private readonly ITagTranslator tagTranslator;
        public HomeController(IDbContext dbContext, ITagTranslator tagTranslator)
        {
            this.dbContext = dbContext;
            this.tagTranslator = tagTranslator;
        }

        public async Task<IActionResult> Index()
        {
            var ongoings = await dbContext.Anime.Include(a => a.Updates).Where(a => a.Tag == tagTranslator.ToString(Tag.Ongoing)).ToListAsync();
            var seasons = await dbContext.Seasons.ToListAsync();
            var model = new IndexViewModel().Initialize(ongoings, null, null, seasons);

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
