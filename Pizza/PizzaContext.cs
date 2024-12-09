using Microsoft.EntityFrameworkCore;

namespace Pizza;

public class PizzaContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order>? Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=pizza.db");
    }
}