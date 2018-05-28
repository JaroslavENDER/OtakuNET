using System.Collections.Generic;

namespace OtakuNET.Domain.Entities
{
    public class UserAnimeList : UserList
    {
        public List<Anime> Anime { get; set; }

        public UserAnimeList()
            => Anime = new List<Anime>();
    }
}
