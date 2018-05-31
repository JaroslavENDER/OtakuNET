using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.AnimangaViewModels;
using OtakuNET.Web.Models.AnimeViewModels;
using OtakuNET.Web.Services;
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
            var titles = await dbContext.Anime.Include(a => a.Updates).OrderByDescending(a => a.Updates.Max(u => u.Timestamp)).ToListAsync();
            var model = new AnimeListViewModel().Initialize(titles);
            return View(model);
        }

        public IActionResult Season(string season)
        {
            return View();
        }
    }
}