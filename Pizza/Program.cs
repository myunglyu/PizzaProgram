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
                Console.WriteLine();
                Console.WriteLine("Press number to vew details or add to cart");
                Console.WriteLine("'x' to exit, 'c' to view cart, 'm' for menu");
                var menuInput = Console.ReadLine();
                Console.WriteLine();

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
                    Console.WriteLine();
                    cart.Display();
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
                            Console.WriteLine("How many?");
                            var quantityInput = Console.ReadLine();
                            if (int.TryParse(quantityInput, out var qty))
                            {
                                if (qty == 0)
                                {
                                    cart.Remove(cart.GetItems()[editNumber - 1]);
                                }
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

                    Console.WriteLine("How many? enter 0 to cancel");
                    var quantityInput = Console.ReadLine();

                    if (int.TryParse(quantityInput, out var qty))
                    {
                        if (qty == 0)
                        {
                            return;
                        }
                        var cartItem = new CartItem { Pizza = pizza, Quantity = qty };
                        cart.Add(cartItem);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }
        }
    }
}
