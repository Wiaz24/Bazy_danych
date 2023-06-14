using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Platformy_Programowania_1.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Uzytkownicy")]
        public string UserId { get; set; } = null!;
        public float Price { get; set; }
        public int Amount { get; set; }
        [ForeignKey("Firmy")]
        public int CompanyId { get; set; }

    }
}
