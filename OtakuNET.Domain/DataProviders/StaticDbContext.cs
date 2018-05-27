using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.Entities;
using System.Threading.Tasks;

namespace OtakuNET.Domain.DataProviders
{
    public class StaticDbContext : DbContext, IDbContext
    {
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<AnimeSeason> Seasons { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<News> News { get; set; }

        private static bool isInitialized = false;

        public async Task<int> SaveChangesAsync()
            => await base.SaveChangesAsync();

        public StaticDbContext(DbContextOptions options)
            : base(options)
        {
            if (isInitialized) return;
            Initialize();
            isInitialized = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => base.OnConfiguring(optionsBuilder);




        private void Initialize()
        {
            Anime.Add(new Anime { Title = "First title" });
            SaveChanges();
        }
    }
}
