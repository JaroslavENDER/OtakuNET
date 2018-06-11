using System;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class Comment
    {
        [Key] public int Id { get; set; }
        [Required] public DateTime Timestamp { get; set; }
        [Required] public string Text { get; set; }

        public Profile Profile { get; set; }

        public Anime Anime { get; set; }
        public Manga Manga { get; set; }
        public News News { get; set; }
    }
}
