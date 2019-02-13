using System;
using System.Collections.Generic;
using System.Linq;
using OtakuNET.Domain.Enums;

namespace OtakuNET.Domain.Entities
{
    public class Title : EntityBase
    {
        public TitleType Type { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string Tag { get; set; }
        public double Rating { get; set; }
        public string StudioName { get; set; }
        public string StudioImageSrc { get; set; }
        public string Description { get; set; }
        public MangaType? MangaType { get; set; }
        public int? AnimeSeasonId { get; set; }

        public AnimeSeason AnimeSeason { get; set; }

        public List<TitleInformation> Information { get; set; } = new List<TitleInformation>();
        public List<TitleLink> Links { get; set; } = new List<TitleLink>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<TitleUpdate> Updates { get; set; } = new List<TitleUpdate>();
        public List<TitleUserList> TitleUserLists { get; set; } = new List<TitleUserList>();
    }
}
