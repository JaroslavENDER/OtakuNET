using System.Collections.Generic;

namespace OtakuNET.Domain.Entities
{
    public class Manga : Animanga
    {
        public List<UserMangaList> UserLists { get; set; }

        public Manga()
            : base()
            => UserLists = new List<UserMangaList>();
    }
}
