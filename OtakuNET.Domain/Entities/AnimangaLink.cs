using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public class AnimangaLink: EntityBase
    {
        public int AnimangaId { get; set; }
        public string Text { get; set; }
        public string Href { get; set; }

        public Animanga Animanga { get; set; }
    }
}
