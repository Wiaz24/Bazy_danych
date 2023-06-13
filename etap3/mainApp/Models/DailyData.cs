namespace Platformy_Programowania_1.Models
{
    public class DailyData
    {
        public int ID { get; set; }
        //public int CompanyId { get; set; }
        public string Name { get; set; }
        //public float Price { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        //public TimeSpan Time { get; set; }
        public double ChangePercent { get; set; }
        public double PreviousClose { get; set; }
        public TimeSpan LastUpdateUtc { get; set; }
    }
}
