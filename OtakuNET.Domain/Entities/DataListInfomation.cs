using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class DataListInfomation
    {
        [Key] public int Id { get; set; }
        [Required] public string Key { get; set; }
        [Required] public string Value { get; set; }

        public Animanga Anime { get; set; }
        public Animanga Manga { get; set; }
        public Update Update { get; set; }
    }
}
