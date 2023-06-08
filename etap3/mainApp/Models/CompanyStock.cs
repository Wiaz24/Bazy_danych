using System.ComponentModel.DataAnnotations;

namespace Platformy_Programowania_1.Models;

public class CompanyStock
{
    public Data? Data { get; set; }
}

public class Data
{
    public IEnumerable<Stock>? Stock { get; set; }
}

public class Stock
{
    [Key]
    public int ID { get; set;}
    public string? Name { get; set; }
    public double Price { get; set; }
    public double Change { get; set; }
    public double ChangePercent { get; set; }
    public double PreviousClose { get; set; }
    public DateTimeOffset LastUpdateUtc { get; set; }
}
