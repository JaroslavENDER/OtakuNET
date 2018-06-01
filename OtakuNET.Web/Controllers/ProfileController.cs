using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions;
using OtakuNET.Web.Models.ProfileViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .FirstOrDefaultAsync(p => string.Equals(p.Login, login, StringComparison.OrdinalIgnoreCase));
            if (profile == null) return NotFound();
            var model = new ProfileViewModel().Initialize(profile, timestampFormatter);
            return View(model);
        }

        public async Task<IActionResult> List(string login, string key)
        {
            var profile = await dbContext.Profiles
                .Include(p => p.AnimeListSet).ThenInclude(l => l.Anime).ThenInclude(a => a.Anime)
                .Include(p => p.MangaListSet).ThenInclude(l => l.Manga).ThenInclude(m => m.Manga)
                .FirstOrDefaultAsync(p => string.Equals(p.Login, login, StringComparison.OrdinalIgnoreCase));
            IEnumerable<UserList> lists;
            if (key == "Anime")
                lists = profile.AnimeListSet;
            else if (key == "Manga")
                lists = profile.MangaListSet;
            else
                lists = (profile.AnimeListSet.Where(l => l.Key == key) as IEnumerable<UserList>).Concat(profile.MangaListSet.Where(l => l.Key == key)).ToList();
            if (lists.Count() == 0) return NotFound();
            var model = new ProfileListViewModel().Initialize(profile, lists);
            return View(model);
        }

        public IActionResult History(string login, string key)
        {
            return View();
        }
    }
}