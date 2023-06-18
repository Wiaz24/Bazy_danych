using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Platformy_Programowania_1.Models
{
    public class Order
    {
        [Key]
        public int ID_zamowienia { get; set; }
        [ForeignKey("aspnetusers")]
        public string ID_uzytkownika { get; set; } = null!;

        [ForeignKey("Companies")]
        public int ID_firmy { get; set; }
        public float Cena { get; set; }
        public int Ilosc { get; set; }
    }
}
