using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OtakuNET.Domain.Contracts;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public interface IUserListRepository : IEntityRepository<UserList>, IContractRepository<UserList, UserListContract>
    {

    }

    public class UserListRepository : EntityRepositoryBase<UserList>, IUserListRepository
    {
        public UserListRepository(IDbContext context)
            : base(context) { }

        public IQueryable<UserListContract> MapToContract(IQueryable<UserList> entities)
        {
            return entities.Select(e => MapToContract(e));
        }

        public UserListContract MapToContract(UserList userList)
        {
            return new UserListContract
            {
                Id = userList.Id,
                Key = userList.Key,
                Name = userList.Name,
                Type = userList.Type,
                Description = userList.Description,
                ProfileId = userList.ProfileId,
                Profile = userList.Profile,
                CreatedAt = userList.CreatedAt,
                UpdatedAt = userList.UpdatedAt,
                TitleList = userList.TitleList.Select(tul => tul.Title).ToList()
            };
        }
    }
}
