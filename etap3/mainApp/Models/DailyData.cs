namespace Platformy_Programowania_1.Models
{
    public class DailyData
    {
        public int ID_rekordu { get; set; }
        public int ID_firmy { get; set; }
        public float Cena { get; set; }
        public TimeSpan Godzina { get; set; }
    }
}
