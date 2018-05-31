using System.Collections.Generic;

namespace OtakuNET.Domain.Entities
{
    public class Manga : Animanga
    {
        public List<Manga_MangaList> UserLists { get; set; }

        public Manga()
            : base()
            => UserLists = new List<Manga_MangaList>();
    }
}
