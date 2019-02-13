using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class Anime : Animanga
    {
        public int SeasonId { get; set; }

        public AnimeSeason Season { get; set; }
        
        public List<Update> Updates { get; set; } = new List<Update>();
        public List<AnimeAnimeList> UserLists { get; set; } = new List<AnimeAnimeList>();
    }
}
