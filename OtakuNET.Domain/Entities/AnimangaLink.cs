using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class AnimangaLink
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(30)] public string Text { get; set; }
        [Required] public string Href { get; set; }

        [Required] public Animanga Animanga { get; set; }
    }
}
