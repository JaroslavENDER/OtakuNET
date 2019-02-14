using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.TitleViewModels;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.TagTranslator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OtakuNET.Domain.Enums;

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
            var title = await dbContext.Titles.Include(m => m.Links).Include(m => m.Information).FirstOrDefaultAsync(m => m.Key == key);
            if (title == null) return NotFound();
            var userLists = new List<UserList>();
            var model = new TitleViewModel().Initialize(title, userLists, tagTranslator);
            return View(model);
        }

        public async Task<IActionResult> List()
        {
            var titles = await dbContext.Titles.OrderByDescending(m => m.Rating).ToListAsync();
            var model = new TitleListViewModel().Initialize(titles, "Манга, отсортированная по рейтингу");
            return View(model);
        }

        public async Task<IActionResult> Type(MangaType key)
        {
            var titles = await dbContext.Titles.Where(m => m.MangaType == key).OrderByDescending(m => m.Rating).ToListAsync();
            var model = new TitleListViewModel().Initialize(titles, $"Манга по запросу: {key}");
            return View("List", model);
        }
    }
}