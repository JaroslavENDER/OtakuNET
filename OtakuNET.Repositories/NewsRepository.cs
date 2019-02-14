using System;
using System.Collections.Generic;
using System.Text;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public interface INewsRepository : IEntityRepository<News>
    {

    }

    public class NewsRepository : EntityRepositoryBase<News>, INewsRepository
    {
        public NewsRepository(IDbContext context)
            : base(context) { }
    }
}
