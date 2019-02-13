using System;
using System.Collections.Generic;
using System.Text;

namespace OtakuNET.Domain.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        bool IsNew();
    }
}
