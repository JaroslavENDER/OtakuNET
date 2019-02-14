using System;
using System.Collections.Generic;
using System.Text;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public interface ITitleUpdateRepository : IEntityRepository<TitleUpdate>
    {

    }

    public class TitleUpdateRepository : EntityRepositoryBase<TitleUpdate>, ITitleUpdateRepository
    {
        public TitleUpdateRepository(IDbContext context)
            : base(context) { }
    }
}
