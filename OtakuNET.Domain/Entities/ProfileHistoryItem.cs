using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class ProfileHistoryItem : EntityBase
    {
        public int ProfileId { get; set; }
        public int AnimeId { get; set; }
        public int MangaId { get; set; }
        public int? UserListId { get; set; }
        public string Text { get; set; }

        public Profile Profile { get; set; }
        public Anime Anime { get; set; }
        public Manga Manga { get; set; }
        public UserList UserList { get; set; }
    }
}
