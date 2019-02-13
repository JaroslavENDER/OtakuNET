using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class Manga : Animanga
    {
        public string Type { get; set; }

        public List<MangaMangaList> UserLists { get; set; } = new List<MangaMangaList>();
    }
}
