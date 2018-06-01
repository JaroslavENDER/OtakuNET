using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.Data;
using OtakuNET.Web.Models;

namespace OtakuNET.Web.Extensions
{
    public static class AddStaticDbContextExtension
    {
        public static void AddStaticDbContextInMemory(this IServiceCollection services, string databaseName)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseInMemoryDatabase(databaseName));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<StaticDbContext>(options
                => options.UseInMemoryDatabase(databaseName));
            services.AddScoped<IDbContext, StaticDbContext>();
        }
    }
}
