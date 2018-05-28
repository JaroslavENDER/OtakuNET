using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class AnimeSeason
    {
        [Key, MaxLength(10)] public string Key { get; set; }
        [Required, MaxLength(15)] public string Name { get; set; }
        [Required, MaxLength(25)] public string FullName { get; set; }

        public List<Anime> Animes { get; set; }

        public AnimeSeason()
            => Animes = new List<Anime>();
    }
}
