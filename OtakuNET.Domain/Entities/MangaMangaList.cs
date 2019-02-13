using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class MangaMangaList : EntityBase
    {
        public int MangaId { get; set; }
        public int UserMangaListId { get; set; }

        public Manga Manga { get; set; }
        public UserMangaList UserMangaList { get; set; }
    }
}
