using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OtakuNET.Domain.DataProviders
{
    public interface IDbContext : IDisposable
    {
        DbSet<Title> Titles { get; set; }
        DbSet<AnimeSeason> Seasons { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<TitleUpdate> TitleUpdates { get; set; }
        DbSet<News> News { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;
        EntityState GetEntityState<TEntity>(TEntity entity) where TEntity : EntityBase;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
