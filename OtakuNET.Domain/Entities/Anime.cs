using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Anime : Animanga
    {
        [Required] public AnimeSeason Season { get; set; }
        
        public List<Update> Updates { get; set; }
        public List<UserAnimeList> UserLists { get; set; }

        public Anime()
            : base()
        {
            Updates = new List<Update>();
            UserLists = new List<UserAnimeList>();
        }
    }
}
