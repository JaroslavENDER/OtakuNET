using System.Collections.Generic;

namespace OtakuNET.Domain.Entities
{
    public class UserMangaList : UserList
    {
        public List<Manga_MangaList> Manga { get; set; }

        public UserMangaList()
            => Manga = new List<Manga_MangaList>();
    }
}
