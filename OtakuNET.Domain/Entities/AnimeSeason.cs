using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class AnimeSeason
    {
        [Key] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string FullName { get; set; }

        public List<Anime> Animes { get; set; }

        public AnimeSeason()
            => Animes = new List<Anime>();
    }
}
