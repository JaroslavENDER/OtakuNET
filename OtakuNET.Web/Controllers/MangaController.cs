using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.ModelExtensions.AnimangaViewModelExtensions;
using OtakuNET.Web.Models.MangaViewModels;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class MangaController : Controller
    {
        private readonly IDbContext dbContext;
        public MangaController(IDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<IActionResult> List()
        {
            var titles = await dbContext.Manga.ToListAsync();
            var model = new MangaListViewModel().Initialize(titles);
            return View(model);
        }

        public IActionResult Title()
        {
            return View();
        }
    }
}