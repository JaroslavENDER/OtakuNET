using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;
using OtakuNET.Web.ModelExtensions.ProfileViewModelsExtensions;
using OtakuNET.Web.Models;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITimestampFormatter timestampFormatter;
        public ProfileController(IDbContext dbContext, UserManager<ApplicationUser> userManager, ITimestampFormatter timestampFormatter)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.timestampFormatter = timestampFormatter;
        }

        [Authorize]
        public async Task<IActionResult> MyProfile()
        {
            var user = await userManager.GetUserAsync(User);
            return await Profile(user.UserName);
        }

        public async Task<IActionResult> Profile(string login)
        {
            var profile = await dbContext.Profiles
                .Include(p => p.Avatar)
                .Include(p => p.UserLists).ThenInclude(l => l.TitleList)
                .Include(p => p.History).ThenInclude(h => h.Title)
                .Include(p => p.History).ThenInclude(h => h.Title)
                .Include(p => p.History).ThenInclude(h => h.UserList)
                .FirstOrDefaultAsync(p => string.Equals(p.Login, login, StringComparison.OrdinalIgnoreCase));
            if (profile == null) return NotFound();
            var model = new ProfileViewModel().Initialize(profile, timestampFormatter);
            return View(nameof(Profile), model);
        }

        public async Task<IActionResult> List(string login, string key)
        {
            var profile = await dbContext.Profiles
                .Include(p => p.UserLists).ThenInclude(l => l.TitleList).ThenInclude(a => a.Title)
                .FirstOrDefaultAsync(p => string.Equals(p.Login, login, StringComparison.OrdinalIgnoreCase));
            if (profile == null) return NotFound();
            IEnumerable<UserList> lists;
            if (key == "Anime")
                lists = profile.UserLists;
            else if (key == "Manga")
                lists = profile.UserLists;
            else
                lists = profile.UserLists.Where(l => l.Key == key).Concat(profile.UserLists.Where(l => l.Key == key)).ToList();
            if (lists.Count() == 0) return NotFound();
            var model = new ProfileListViewModel().Initialize(profile, lists);
            return View(model);
        }

        public async Task<IActionResult> History(string login, string key)
        {
            var profile = await dbContext.Profiles
                .Include(p => p.History).ThenInclude(h => h.Title)
                .Include(p => p.History).ThenInclude(h => h.UserList)
                .FirstOrDefaultAsync(p => string.Equals(p.Login, login, StringComparison.OrdinalIgnoreCase));
            if (profile == null) return NotFound();
            var model = new ProfileHistoryViewModel().Initialize(profile, timestampFormatter);
            return View(model);
        }
    }
}