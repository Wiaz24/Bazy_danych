﻿using System.ComponentModel.DataAnnotations;

namespace Platformy_Programowania_1.Models
{
    public class YearlyData
    {
        [Key]
        public int ID_rekordu { get; set; }
        public int ID_firmy { get; set; }
        public float Cena { get; set; }
        public DateTime Dzien { get; set; }
    }
}
