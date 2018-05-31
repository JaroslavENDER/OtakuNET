using System.Collections.Generic;

namespace OtakuNET.Domain.Entities
{
    public class UserAnimeList : UserList
    {
        public List<Anime_AnimeList> Anime { get; set; }

        public UserAnimeList()
            => Anime = new List<Anime_AnimeList>();
    }
}
