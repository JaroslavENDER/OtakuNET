using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Anime_AnimeList
    {
        [Key] public int Id { get; set; }
        [Required] public Anime Anime { get; set; }
        [Required] public UserAnimeList List { get; set; }
    }
}
