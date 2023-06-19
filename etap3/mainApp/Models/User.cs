using Microsoft.AspNetCore.Identity;

namespace Bazy_danych.Models
{
    public class User : IdentityUser
    { 
        public float Balance { get; set; }
        public int AccountType { get; set; }
    }
}
