using System;
using System.Collections.Generic;
using System.Text;
using OtakuNET.Domain.Entities;
using OtakuNET.Domain.Enums;

namespace OtakuNET.Domain.Contracts
{
    public class UserListContract : EntityBase
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public TitleType Type { get; set; }
        public string Description { get; set; }
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }

        public List<Title> TitleList { get; set; } = new List<Title>();
    }
}
