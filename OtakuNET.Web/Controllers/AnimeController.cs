using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.AnimangaViewModels;
using OtakuNET.Web.Models.AnimeViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IDbContext dbContext;
        private readonly ITagTranslator tagTranslator;
        public AnimeController(IDbContext dbContext, ITagTranslator tagTranslator)
        {
            this.dbContext = dbContext;
            this.tagTranslator = tagTranslator;
        }

        public async Task<IActionResult> Title(string key)
        {
            var title = await dbContext.Anime.Include(a => a.Links).Include(a => a.Information).FirstOrDefaultAsync(a => a.Key == key);
            if (title == null) return NotFound();
            var userLists = new List<UserAnimeList>();
            var model = new TitleViewModel().Initialize(title, userLists, tagTranslator);
            return View(model);
        }

        public async Task<IActionResult> List()
        {
            var titles = await dbContext.Anime.OrderByDescending(a => a.Raiting).ToListAsync();
            var model = new AnimeListViewModel().Initialize(titles, "Аниме, отсортированные по рейтингу");
            return View(model);
        }

        public async Task<IActionResult> Season(string key)
        {
            var season = await dbContext.Seasons.Include(s => s.Animes).FirstOrDefaultAsync(s => s.Key == key);
            if (season == null) return NotFound();
            var model = new AnimeListViewModel().Initialize(season.Animes.OrderByDescending(a => a.Raiting), season.FullName);
            return View("List", model);
        }

        public async Task<IActionResult> Studio(string key)
        {
            var titles = await dbContext.Anime.Where(a => a.StudioName == key).OrderByDescending(a => a.Raiting).ToListAsync();
            var model = new AnimeListViewModel().Initialize(titles, $"Аниме студии {key}");
            return View("List", model);
        }
    }
}