using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OtakuNET.Web.Extensions;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.ProfileCreater;
using OtakuNET.Web.Services.TagTranslator;

namespace OtakuNET.Web
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStaticDbContextInMemory("OtakuNET-InMemoryDatabase");
            services.AddIdentity();
            
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ITagTranslator, TagTranslatorEng>();
            services.AddTransient<ITimestampFormatter, TimestampFormatter>();
            services.AddTransient<IProfileCreater, ProfileCreater>();

            services.AddMvc();
        }
        
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
                    template: "Profile/{login}/{action=Profile}/{key?}",
                    defaults: new { controller = "Profile" });
                routes.MapRoute(
                    name: "news",
                    template: "News/{action=News}/{key?}",
                    defaults: new { controller = "News" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{key?}");
            });
        }
    }
}
