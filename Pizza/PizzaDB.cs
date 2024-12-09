using Microsoft.EntityFrameworkCore;

namespace Pizza;

public class Pizza
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public List<string>? Ingredients { get; set; }

}

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string[] OrderDetail { get; set; }
}