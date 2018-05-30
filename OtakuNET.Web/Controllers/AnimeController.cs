using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.AnimeViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IDbContext dbContext;
        public AnimeController(IDbContext dbContext)
            => this.dbContext = dbContext;

        public IActionResult Title(int id)
        {
            return View();
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