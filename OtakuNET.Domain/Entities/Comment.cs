using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class Comment : EntityBase
    {
        public int ProfileId { get; set; }
        public int? TitleId { get; set; }
        public int? NewsId { get; set; }
        public string Text { get; set; }

        public Profile Profile { get; set; }

        public Title Title { get; set; }
        public News News { get; set; }
    }
}
