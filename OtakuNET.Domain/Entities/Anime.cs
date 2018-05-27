using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Anime : Animanga
    {
        [Required] public AnimeSeason Season { get; set; }
    }
}
