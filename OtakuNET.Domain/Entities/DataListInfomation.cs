using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class DataListInfomation
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(30)] public string Key { get; set; }
        [Required] public string Value { get; set; }

        public Anime Anime { get; set; }
        public Manga Manga { get; set; }
        public Update Update { get; set; }
    }
}
