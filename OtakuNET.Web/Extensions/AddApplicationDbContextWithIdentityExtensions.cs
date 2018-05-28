using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OtakuNET.Web.Data;
using OtakuNET.Web.Models;

namespace OtakuNET.Web.Extensions
{
    public static class AddApplicationDbContextWithIdentityExtensions
    {
        public static void AddApplicationDbContextWithIdentity(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
