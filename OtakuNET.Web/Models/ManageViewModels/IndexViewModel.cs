using System.ComponentModel.DataAnnotations;

namespace OtakuNET.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Login { get; set; }
        
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string StatusMessage { get; set; }
    }
}
