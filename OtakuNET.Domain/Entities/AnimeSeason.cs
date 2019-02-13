using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class AnimeSeason : EntityBase
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }

        public List<Title> AnimeList { get; set; } = new List<Title>();
    }
}
