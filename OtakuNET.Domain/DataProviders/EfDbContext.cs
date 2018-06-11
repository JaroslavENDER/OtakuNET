using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.Entities;
using System.Threading.Tasks;

namespace OtakuNET.Domain.DataProviders
{
    public class EfDbContext : DbContext, IDbContext
    {
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<AnimeSeason> Seasons { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<News> News { get; set; }

        public async Task<int> SaveChangesAsync()
            => await base.SaveChangesAsync();

        public EfDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => base.OnConfiguring(optionsBuilder);
    }
}
