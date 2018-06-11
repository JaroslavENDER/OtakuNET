using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Profile
    {
        [Key] public string Id { get; set; }
        [Required] public string Login { get; set; }
        public string Name { get; set; }

        public Image Avatar { get; set; }
        
        public List<UserAnimeList> AnimeListSet { get; set; }
        public List<UserMangaList> MangaListSet { get; set; }
        public List<ProfileHistoryItem> History { get; set; }
        public List<Comment> Comments { get; set; }

        public Profile()
        {
            AnimeListSet = new List<UserAnimeList>();
            MangaListSet = new List<UserMangaList>();
            History = new List<ProfileHistoryItem>();
            Comments = new List<Comment>();
        }
    }
}
