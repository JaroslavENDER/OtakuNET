using System;
using System.Collections.Generic;
using System.Text;

namespace OtakuNET.Domain.Entities
{
    public class TitleUserList : EntityBase
    {
        public int TitleId { get; set; }
        public int UserListId { get; set; }

        public Title Title { get; set; }
        public UserList UserList { get; set; }
    }
}
