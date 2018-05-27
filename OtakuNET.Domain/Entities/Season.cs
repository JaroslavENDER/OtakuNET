using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Season
    {
        [Key] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string FullName { get; set; }

        public List<Animanga> Animes { get; set; }

        public Season()
            => Animes = new List<Animanga>();
    }
}
