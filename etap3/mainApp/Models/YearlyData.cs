using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazy_danych.Models
{
    public class YearlyData
    {
        [Key]
        public int ID_rekordu { get; set; }
        [ForeignKey("Company")]
        public int ID_firmy { get; set; }
        public float Cena { get; set; }
        public DateTime Dzien { get; set; }
    }
}
