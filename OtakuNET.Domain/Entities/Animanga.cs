using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Animanga
    {
        [Key] public string Title { get; set; }
        public string ImageSrc { get; set; }
        [Required] public string Tag { get; set; }
        [Required] public double Raiting { get; set; }
        [Required] public string StudioName { get; set; }
        public string StudioImageSrc { get; set; }
        public string Description { get; set; }
        
        public Season Season { get; set; }

        public List<DataListInfomation> Information { get; set; }
        public List<DataListInfomation> Links { get; set; }

        public Animanga()
        {
            Information = new List<DataListInfomation>();
            Links = new List<DataListInfomation>();
        }
    }
}
