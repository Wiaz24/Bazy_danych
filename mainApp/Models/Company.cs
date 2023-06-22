using System.ComponentModel.DataAnnotations;

namespace Bazy_danych.Models
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
