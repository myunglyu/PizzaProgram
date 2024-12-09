namespace Pizza;

public class PizzaMenu
{
    public static void Display()
    { 
        var context = new PizzaContext();

        // Query pizzas
        var pizzas = context.Pizzas.ToList();

        // Print table header
        Console.WriteLine("{0, 5} {1,-15} {2,-40} {3,10}", "No.", "Name", "Description", "Price");
        Console.WriteLine(new string('-', 73));

        // Print table rows
        var number = 1;
        foreach (var p in pizzas)
        {
            Console.WriteLine("{0, 5} {1,-15} {2,-40} {3,10:C}", number, p.Name, p.Description, p.Price);
            number++;
        }
    }

    public static void DisplayDetails(Pizza pizza)
    {
        Console.WriteLine($"Name: {pizza.Name}");
        Console.WriteLine($"Description: {pizza.Description}");
        Console.WriteLine($"Price: {pizza.Price:C}");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in pizza.Ingredients)
        {
            Console.Write($"{ingredient}, ");
        }
        Console.WriteLine();
    }
}