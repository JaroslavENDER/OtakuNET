using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class DataListInformation : EntityBase
    {
        public int? AnimeId { get; set; }
        public int? MangaId { get; set; }
        public int? UpdateId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public Anime Anime { get; set; }
        public Manga Manga { get; set; }
        public Update Update { get; set; }
    }
}
