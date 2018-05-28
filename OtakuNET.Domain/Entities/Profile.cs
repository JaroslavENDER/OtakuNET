using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Profile
    {
        [Key] public int Id { get; set; }

        public List<UserAnimeList> AnimeListSet { get; set; }
        public List<UserMangaList> MangaListSet { get; set; }

        public Profile()
        {
            AnimeListSet = new List<UserAnimeList>();
            MangaListSet = new List<UserMangaList>();
        }
    }
}
