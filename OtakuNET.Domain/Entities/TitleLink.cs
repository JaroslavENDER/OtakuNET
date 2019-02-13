using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class TitleLink: EntityBase
    {
        public string Text { get; set; }
        public string Href { get; set; }
        public int TitleId { get; set; }

        public Title Title { get; set; }
    }
}
