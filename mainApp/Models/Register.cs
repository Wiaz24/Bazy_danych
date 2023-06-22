using System.ComponentModel.DataAnnotations;

namespace Bazy_danych.Models
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
