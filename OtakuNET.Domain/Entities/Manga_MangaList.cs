using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Manga_MangaList
    {
        [Key] public int Id { get; set; }
        [Required] public Manga Manga { get; set; }
        [Required] public UserMangaList List { get; set; }
    }
}
