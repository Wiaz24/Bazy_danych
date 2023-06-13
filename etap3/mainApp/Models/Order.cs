namespace Platformy_Programowania_1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public float Price { get; set; }
        public int Amount { get; set; }
        public int CompanyId { get; set; }

    }
}
