using Microsoft.EntityFrameworkCore;

namespace Pizza;

public class PizzaContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=pizza.db");
    }
}

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