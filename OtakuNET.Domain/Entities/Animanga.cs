using System;
using System.Collections.Generic;
using System.Linq;

namespace OtakuNET.Domain.Entities
{
    public abstract class Animanga : EntityBase
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public string Tag { get; set; }
        public double Rating { get; set; }
        public string StudioName { get; set; }
        public string StudioImageSrc { get; set; }
        public string Description { get; set; }

        public List<DataListInformation> Information { get; set; } = new List<DataListInformation>();
        public List<AnimangaLink> Links { get; set; } = new List<AnimangaLink>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
