using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class Profile : EntityBase
    {
        public int? AvatarId { get; set; }
        public string ApplicationUserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }

        public Image Avatar { get; set; }
        
        public List<UserAnimeList> AnimeList { get; set; } = new List<UserAnimeList>();
        public List<UserMangaList> MangaList { get; set; } = new List<UserMangaList>();
        public List<ProfileHistoryItem> History { get; set; } = new List<ProfileHistoryItem>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
