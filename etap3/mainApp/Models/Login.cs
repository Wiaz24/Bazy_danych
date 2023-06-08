using System.ComponentModel.DataAnnotations;
namespace Platformy_Programowania_1.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
