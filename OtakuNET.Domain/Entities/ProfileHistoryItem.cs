using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class ProfileHistoryItem : EntityBase
    {
        public int ProfileId { get; set; }
        public string Text { get; set; }
        public int? TitleId { get; set; }
        public int? TitleUserListId { get; set; }

        public Profile Profile { get; set; }
        public Title Title { get; set; }
        public UserList UserList { get; set; }
    }
}
