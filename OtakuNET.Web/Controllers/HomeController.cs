using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.ModelExtensions.HomeViewModelsExtentions;
using OtakuNET.Web.Models;
using OtakuNET.Web.Models.HomeViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITagTranslator tagTranslator;
        public HomeController(IDbContext dbContext, UserManager<ApplicationUser> userManager, ITagTranslator tagTranslator)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.tagTranslator = tagTranslator;
        }

        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);
            var profile = await dbContext.Profiles.Include(p => p.AnimeList).Include(p => p.MangaList).FirstOrDefaultAsync(p => p.ApplicationUserId == userId);
            var animeUserLists = profile?.AnimeList;
            var mangaUserLists = profile?.MangaList;
            var ongoings = await dbContext.Anime.Include(a => a.Updates).Where(a => a.Tag == tagTranslator.ToString(Tag.Ongoing)).ToListAsync();
            var seasons = await dbContext.Seasons.ToListAsync();
            var model = new IndexViewModel().Initialize(profile?.Login, ongoings, animeUserLists, mangaUserLists, seasons);

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
