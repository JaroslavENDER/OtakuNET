using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OtakuNET.Web.Extensions;
using OtakuNET.Web.Services;

namespace OtakuNET.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationDbContextWithIdentity(Configuration.GetConnectionString("ApplicationConnection"));

            services.AddStaticDbContextInMemory("OtakuNET-InMemoryDatabase");
            
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ITagTranslator, TagTranslator>();
            services.AddTransient<ITimestampFormatter, TimestampFormatter>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "profile",
                    template: "Profile/{login}/{action=Profile}/{param?}",
                    defaults: new { controller = "Profile" });
                routes.MapRoute(
                    name: "news",
                    template: "News/{action=News}",
                    defaults: new { controller = "News" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{param?}");
            });
        }
    }
}
