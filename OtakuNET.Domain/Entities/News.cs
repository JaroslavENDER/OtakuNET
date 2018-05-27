using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public class News : NewsBase
    {
        [Required] public string Text { get; set; }
    }
}
