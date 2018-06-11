using Ender.TimestampFormatterCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OtakuNET.Web.Extensions;
using OtakuNET.Web.Services;
using OtakuNET.Web.Services.CommentCreater;
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
            //Use this
            services.AddStaticDbContextInMemory("OtakuNET-InMemoryDatabase");
            //or this + OtakuNET.DatabaseInitializer
            //services.AddEfDbContext(Configuration.GetConnectionString("EfConnection"));

            services.AddIdentity();
            
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ITagTranslator, TagTranslatorEng>();
            services.AddTransient<ITimestampFormatter, TimestampFormatter>();
            services.AddTransient<IProfileCreater, ProfileCreater>();
            services.AddTransient<ICommentCreater, CommentCreater>();

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
                    name: "image",
                    template: "Image/{id}",
                    defaults: new { controller = "Image", action = "Get" });
                routes.MapRoute(
                    name: "my-profile",
                    template: "Profile",
                    defaults: new { controller = "Profile", action = "MyProfile" });
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
