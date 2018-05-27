using System;
using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class News
    {
        [Key] public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public DateTime Timestamp { get; set; }
        public string ImageSrc { get; set; }
        [Required] public string Text { get; set; }
    }
}
