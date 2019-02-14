using System;
using System.Collections.Generic;
using System.Text;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public interface IAnimeSeasonRepository : IEntityRepository<AnimeSeason>
    {

    }

    public class AnimeSeasonRepository : EntityRepositoryBase<AnimeSeason>, IAnimeSeasonRepository
    {
        public AnimeSeasonRepository(IDbContext context)
            : base(context) { }
    }
}
