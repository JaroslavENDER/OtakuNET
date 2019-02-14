using System;
using System.Collections.Generic;
using System.Text;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public interface IProfileRepository : IEntityRepository<Profile>
    {

    }

    public class ProfileRepository : EntityRepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(IDbContext context)
            : base(context) { }
    }
}
