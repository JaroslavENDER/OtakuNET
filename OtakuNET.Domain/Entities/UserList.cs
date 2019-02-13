using System;
using System.Collections.Generic;
using System.Linq;
using OtakuNET.Domain.Enums;

namespace OtakuNET.Domain.Entities
{
    public class UserList : EntityBase
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public TitleType Type { get; set; }
        public string Description { get; set; }
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }

        public List<TitleUserList> TitleList { get; set; } = new List<TitleUserList>();
    }
}
