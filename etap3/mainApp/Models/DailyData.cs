namespace Platformy_Programowania_1.Models
{
    public class DailyData
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public float Price { get; set; }
        public TimeSpan Time { get; set; }
    }
}
