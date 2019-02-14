using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OtakuNET.Domain.Contracts;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public interface ITitleRepository : IEntityRepository<Title>, IContractRepository<Title, TitleContract>
    {

    }

    public class TitleRepository : EntityRepositoryBase<Title>, ITitleRepository
    {
        public TitleRepository(IDbContext context)
            : base(context) { }

        public IQueryable<TitleContract> MapToContract(IQueryable<Title> entities)
        {
            return entities.Select(e => MapToContract(e));
        }

        public TitleContract MapToContract(Title title)
        {
            return new TitleContract
            {
                Id = title.Id,
                Key = title.Key,
                Name = title.Name,
                Type = title.Type,
                ImageSrc = title.ImageSrc,
                Tag = title.Tag,
                Rating = title.Rating,
                StudioImageSrc = title.StudioImageSrc,
                StudioName = title.StudioName,
                Description = title.Description,
                MangaType = title.MangaType,
                CreatedAt = title.CreatedAt,
                UpdatedAt = title.UpdatedAt,
                AnimeSeasonId = title.AnimeSeasonId,
                AnimeSeason = title.AnimeSeason,
                Information = title.Information,
                Links = title.Links,
                Comments = title.Comments,
                Updates = title.Updates,
                UserLists = title.TitleUserLists.Select(tul => tul.UserList).ToList()
            };
        }
    }
}
