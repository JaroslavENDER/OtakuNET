using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class TitleUpdate : EntityBase
    {
        public int TitleId { get; set; }
        public string Tag { get; set; }

        public Title Title { get; set; }

        public List<TitleInformation> Information { get; set; } = new List<TitleInformation>();
    }
}
