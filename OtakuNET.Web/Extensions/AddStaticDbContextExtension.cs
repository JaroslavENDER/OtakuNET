using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OtakuNET.Domain.DataProviders;

namespace OtakuNET.Web.Extensions
{
    public static class AddStaticDbContextExtension
    {
        public static void AddStaticDbContextInMemory(this IServiceCollection services, string databaseName)
        {
            services.AddDbContext<StaticDbContext>(options
                => options.UseInMemoryDatabase(databaseName));
            services.AddScoped<IDbContext, StaticDbContext>();
        }
    }
}
