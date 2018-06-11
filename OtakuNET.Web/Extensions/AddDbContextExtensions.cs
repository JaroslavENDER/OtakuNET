using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Web.Data;
using OtakuNET.Web.Models;

namespace OtakuNET.Web.Extensions
{
    public static class AddDbContextExtensions
    {
        public static void AddStaticDbContextInMemory(this IServiceCollection services, string databaseName)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseInMemoryDatabase(databaseName));

            services.AddDbContext<StaticDbContext>(options
                => options.UseInMemoryDatabase(databaseName));

            services.AddScoped<IDbContext, StaticDbContext>();
        }

        public static void AddEfDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(connectionString));

            services.AddDbContext<EfDbContext>(options
                => options.UseSqlServer(connectionString));

            services.AddScoped<IDbContext, EfDbContext>();
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
