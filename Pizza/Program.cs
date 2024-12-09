namespace Pizza
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Pizza Shop");
            PizzaMenu.Display();
            var cart = new PizzaCart();

            while (true)
            {
                Console.WriteLine("Press number to vew details");
                Console.WriteLine("'x' to exit, 'c' to view cart, 'm' for menu");
                var menuInput = Console.ReadLine();
                if (menuInput.ToLower() == "m")
                {
                    PizzaMenu.Display();
                    continue;
                }
                if (menuInput.ToLower() == "x")
                {
                    Console.WriteLine("Exiting the program. Thank you for visiting Pizza Shop!");
                    return;
                }

                if (menuInput.ToLower() == "c")
                {
                    Console.WriteLine("Proceeding to checkout");
                    Console.WriteLine("Current Cart:");
                    Console.WriteLine($"{"No.", 3}  {"Pizza",-15} {"Qty",5} {"Price",10}");
                    Console.WriteLine(new string('-', 35));
                    var sum = 0m;
                    var listNumber = 1;
                    foreach (var item in cart.GetItems())
                    {
                        var price = item.Pizza.Price * item.Quantity;
                        Console.WriteLine($"{listNumber, 3}  {item.Pizza.Name,-15} {item.Quantity,5} {price,10}");
                        sum += price;
                        listNumber++;
                    }
                    Console.WriteLine($"Total: {sum}");
                    Console.WriteLine("Would you like to proceed? [y] to proceed, [e] to edit cart");
                    var proceed = Console.ReadLine();
                    if (proceed.ToLower() == "y")
                    {
                        Console.WriteLine("Enter your name:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Enter your address:");
                        var address = Console.ReadLine();
                        PizzaCart.PlaceOrder(name, address, cart);
                        Console.WriteLine("Thank you for using Pizza Program!");
                        return;
                    }
                    if (proceed.ToLower() == "e")
                    {
                        Console.WriteLine("Enter the number of the item you want to edit");
                        var editInput = Console.ReadLine();
                        if (int.TryParse(editInput, out var editNumber))
                        {
                            var pizza = cart.GetItems()[editNumber - 1].Pizza;
                            PizzaMenu.DisplayDetails(pizza);
                            Console.WriteLine("How many?");
                            var quantityInput = Console.ReadLine();
                            if (int.TryParse(quantityInput, out var qty))
                            {
                                var cartItem = new CartItem { Pizza = pizza, Quantity = qty };
                                cart.Update(cartItem);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                    }
                }

                if (int.TryParse(menuInput, out var number))
                {
                    using var context = new PizzaContext();
                    var pizza = context.Pizzas.ToList()[number - 1];
                    PizzaMenu.DisplayDetails(pizza);

                    Console.WriteLine("How many?");
                    var quantityInput = Console.ReadLine();

                    if (int.TryParse(quantityInput, out var qty))
                    {
                        var cartItem = new CartItem { Pizza = pizza, Quantity = qty };
                        cart.Add(cartItem);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }

                    Console.WriteLine("Current Cart:");
                    foreach (var item in cart.GetItems())
                    {
                        Console.WriteLine($"Pizza: {item.Pizza.Name}, Quantity: {item.Quantity}");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}
