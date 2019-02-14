using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public interface IContractRepository<in TEntity, out TContract> where TEntity : EntityBase where TContract: EntityBase
    {
        IQueryable<TContract> MapToContract(IQueryable<TEntity> entities);
        TContract MapToContract(TEntity entity);
    }
}
