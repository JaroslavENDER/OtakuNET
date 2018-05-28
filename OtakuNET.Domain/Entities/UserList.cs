using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Domain.Entities
{
    public abstract class UserList
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(100)] public string Name { get; set; }
        public string Description { get; set; }

        [Required] public Profile Profile { get; set; }
    }
}
