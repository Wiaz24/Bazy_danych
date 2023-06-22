using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazy_danych.Models
{
    public class DailyData
    {
        [Key]
        public int ID_rekordu { get; set; }
        [ForeignKey("Firmy")]
        public int ID_firmy { get; set; }
        public float Cena { get; set; }
        public TimeSpan Godzina { get; set; }
    }
}
