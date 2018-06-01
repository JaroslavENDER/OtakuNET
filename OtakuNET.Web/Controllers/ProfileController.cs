using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions;
using OtakuNET.Web.Models.ProfileViewModels;
using System.Threading.Tasks;

namespace OtakuNET.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IDbContext dbContext;
        private readonly ITimestampFormatter timestampFormatter;
        public ProfileController(IDbContext dbContext, ITimestampFormatter timestampFormatter)
        {
            this.dbContext = dbContext;
            this.timestampFormatter = timestampFormatter;
        }

        public async Task<IActionResult> Profile(string login)
        {
            var profile = await dbContext.Profiles
                .Include(p => p.AnimeListSet).ThenInclude(l => l.Anime)
                .Include(p => p.MangaListSet).ThenInclude(l => l.Manga)
                .Include(p => p.History).ThenInclude(h => h.Anime)
                .Include(p => p.History).ThenInclude(h => h.Manga)
                .Include(p => p.History).ThenInclude(h => h.UserList)
                .FirstOrDefaultAsync(p => string.Equals(p.Login, login, System.StringComparison.OrdinalIgnoreCase));
            if (profile == null) return NotFound();
            var model = new ProfileViewModel().Initialize(profile, timestampFormatter);
            return View(model);
        }

        public IActionResult List(string login, string key)
        {
            return View();
        }

        public IActionResult History(string login, string key)
        {
            return View();
        }
    }
}