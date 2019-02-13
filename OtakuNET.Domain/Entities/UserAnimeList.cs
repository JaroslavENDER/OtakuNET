using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class UserAnimeList : UserList
    {
        public List<AnimeAnimeList> Anime { get; set; } = new List<AnimeAnimeList>();
    }
}
