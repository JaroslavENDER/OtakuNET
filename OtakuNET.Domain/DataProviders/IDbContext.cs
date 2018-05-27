using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OtakuNET.Domain.DataProviders
{
    public interface IDbContext : IDisposable
    {
        DbSet<Animanga> Anime { get; set; }
        DbSet<Animanga> Manga { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<Update> Updates { get; set; }
        DbSet<News> News { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
