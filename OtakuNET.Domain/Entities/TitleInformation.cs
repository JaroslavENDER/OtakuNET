using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class TitleInformation : EntityBase
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int? TitleId { get; set; }
        public int? TitleUpdateId { get; set; }

        public Title Tile { get; set; }
        public TitleUpdate TitleUpdate { get; set; }
    }
}
