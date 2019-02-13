using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class AnimeAnimeList : EntityBase
    {
        public int AnimeId { get; set; }
        public int UserAnimeListId { get; set; }

        public Anime Anime { get; set; }
        public UserAnimeList UserAnimeList { get; set; }
    }
}
