using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Pizza;

public class PizzaContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order>? Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=pizza.db");
    }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .Property(p => p.Ingredients)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza 
                { 
                    Id = 1, 
                    Name = "Supreme", 
                    Description = "Pizza with many Ingredients", 
                    Price = 15.99m,
                    Ingredients = new List<string> { "Pepperoni", "Sausage", "Bacon", "Ham", "Beef", "Mushroom", "Bell Peppers", "Onions", "Mushrooms", "Olives", "Tomato Sauce" }
                },
                new Pizza 
                { 
                    Id = 2, 
                    Name = "Pepperoni", 
                    Description = "Classic pizza with pepperoni", 
                    Price = 9.99m,
                    Ingredients = new List<string> { "Pepperoni", "Mozzarella", "Tomato Sauce" }
                },
                new Pizza 
                { 
                    Id = 3, 
                    Name = "Cheese", 
                    Description = "Simple and delicious cheese pizza", 
                    Price = 9.99m,
                    Ingredients = new List<string> { "Mozzarella", "Cheddar", "Parmesan", "Tomato Sauce" }
                },
                new Pizza 
                { 
                    Id = 4, 
                    Name = "Veggie", 
                    Description = "A healthy pizza loaded with vegetables", 
                    Price = 12.99m,
                    Ingredients = new List<string> { "Bell Peppers", "Onions", "Mushrooms", "Olives", "Tomato Sauce" }
                },
                new Pizza 
                { 
                    Id = 5, 
                    Name = "Meat Lover", 
                    Description = "Pizza for meat enthusiasts", 
                    Price = 14.99m,
                    Ingredients = new List<string> { "Pepperoni", "Sausage", "Bacon", "Ham", "Beef", "Mozzarella", "Tomato Sauce" }
                },
                new Pizza 
                { 
                    Id = 6, 
                    Name = "Build Your Own", 
                    Description = "Pizza with your choice of Toppings", 
                    Price = 14.99m,
                    Ingredients = new List<string> { "Mozzarella", "Tomato Sauce" }
                }
            );
        }
}