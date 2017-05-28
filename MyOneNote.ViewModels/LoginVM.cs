using System.ComponentModel.DataAnnotations;

namespace MyOneNote.ViewModels
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}