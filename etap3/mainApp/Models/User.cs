using Microsoft.AspNetCore.Identity;

namespace Platformy_Programowania_1.Models
{
    public class User : IdentityUser
    { 
        public float Balance { get; set; }
        public int AccountType { get; set; }
    }
}
