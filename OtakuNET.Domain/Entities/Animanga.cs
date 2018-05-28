using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public abstract class Animanga
    {
        [Key] public string Title { get; set; }
        public string ImageSrc { get; set; }
        [Required, MaxLength(10)] public string Tag { get; set; }
        [Required, Range(0, 10)] public double Raiting { get; set; }
        [Required, MaxLength(40)] public string StudioName { get; set; }
        public string StudioImageSrc { get; set; }
        public string Description { get; set; }

        public List<DataListInfomation> Information { get; set; }
        public List<AnimangaLink> Links { get; set; }

        public Animanga()
        {
            Information = new List<DataListInfomation>();
            Links = new List<AnimangaLink>();
        }
    }
}
