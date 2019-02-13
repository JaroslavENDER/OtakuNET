using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class UserMangaList : UserList
    {
        public List<MangaMangaList> Manga { get; set; } = new List<MangaMangaList>();
    }
}
