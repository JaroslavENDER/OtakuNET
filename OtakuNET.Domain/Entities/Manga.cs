using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Manga : Animanga
    {
        [Required] public string Type { get; set; }

        public List<Manga_MangaList> UserLists { get; set; }

        public Manga()
            : base()
            => UserLists = new List<Manga_MangaList>();
    }
}
