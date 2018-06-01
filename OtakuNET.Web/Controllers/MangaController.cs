using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.AnimangaViewModels;
using OtakuNET.Web.Models.MangaViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class MangaController : Controller
    {
        private readonly IDbContext dbContext;
        private readonly ITagTranslator tagTranslator;
        public MangaController(IDbContext dbContext, ITagTranslator tagTranslator)
        {
            this.dbContext = dbContext;
            this.tagTranslator = tagTranslator;
        }

        public async Task<IActionResult> Title(string key)
        {   
            var title = await dbContext.Manga.Include(m => m.Links).Include(m => m.Information).FirstOrDefaultAsync(m => m.Key == key);
            if (title == null) return NotFound();
            var userLists = new List<UserAnimeList>();
            var model = new TitleViewModel().Initialize(title, userLists, tagTranslator);
            return View(model);
        }

        public async Task<IActionResult> List()
        {
            var titles = await dbContext.Manga.OrderByDescending(m => m.Raiting).ToListAsync();
            var model = new MangaListViewModel().Initialize(titles, "Манга, отсортированная по рейтингу");
            return View(model);
        }

        public async Task<IActionResult> Type(string key)
        {
            var titles = await dbContext.Manga.Where(m => m.Type == key).OrderByDescending(m => m.Raiting).ToListAsync();
            var model = new MangaListViewModel().Initialize(titles, $"Манга по запросу: {key}");
            return View("List", model);
        }
    }
}