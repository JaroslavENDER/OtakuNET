using System;
using System.Collections.Generic;
using System.Text;
using OtakuNET.Domain.Entities;
using OtakuNET.Domain.Enums;

namespace OtakuNET.Domain.Contracts
{
    public class TitleContract : EntityBase
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public TitleType Type { get; set; }
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
        public List<UserList> UserLists { get; set; } = new List<UserList>();
    }
}
