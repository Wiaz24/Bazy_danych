using System.ComponentModel.DataAnnotations;

namespace Platformy_Programowania_1.Models
{
    public class Company
    {
        [Key]
        public int ID_firmy { get; set; }
        public string Nazwa_firmy { get; set; } = null!;
        public string Sektor { get; set; } = null!;
        public int Ilosc_dostepnych_akcji { get; set; }
    }
}
