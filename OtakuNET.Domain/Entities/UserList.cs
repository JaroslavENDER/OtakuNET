using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public abstract class UserList : EntityBase
    {
        public int ProfileId { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Profile Profile { get; set; }
    }
}
