using System;

namespace Pizza
{
    public class CartItem
    {
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; } = 1;
    }

    public class PizzaCart
    {
        private List<CartItem> cartItems;

        public PizzaCart()
        {
            cartItems = new List<CartItem>();
        }

        public void Add(CartItem item)
        {
            cartItems.Add(item);
            Console.WriteLine($"{item.Quantity} {item.Pizza.Name} Added to cart");
        }

        public void Remove(CartItem item)
        {
            cartItems.Remove(item);
            Console.WriteLine($"{item.Quantity} {item.Pizza.Name} Removed from cart");
        }

        public void Update(CartItem item)
        {
            var existingItem = cartItems.FirstOrDefault(ci => ci.Pizza.Id == item.Pizza.Id);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
                Console.WriteLine($"{item.Quantity} {item.Pizza.Name} Updated in cart");
            }

        }

        public List<CartItem> GetItems()
        {
            return cartItems;
        }

        public void Display()
        {
            Console.WriteLine("Current Cart:");
            Console.WriteLine($"{"No.", 3}  {"Pizza",-15} {"Qty",5} {"Price",10}");
            Console.WriteLine(new string('-', 38));
            var sum = 0m;
            var listNumber = 1;
            foreach (var item in this.GetItems())
            {
                var price = item.Pizza.Price * item.Quantity;
                Console.WriteLine($"{listNumber, 3}  {item.Pizza.Name,-15} {item.Quantity,5} {price,10}");
                sum += price;
                listNumber++;
            }
            Console.WriteLine();
            Console.WriteLine($"{' ', 15}Total: $ {sum}");
        }

        public static void PlaceOrder(string name, string address, PizzaCart cart)
        {
            try
            {
                using var context = new PizzaContext();
                var order = new Order();

                order.CustomerName = name;
                order.CustomerAddress = address;

                var orderDetail = new List<string>();
                foreach (var item in cart.GetItems())
                {
                    orderDetail.Add($"{item.Pizza.Name} x {item.Quantity}");
                }
                order.OrderDetail = orderDetail.ToArray();

                context.Orders.Add(order);
                context.SaveChanges();
                Console.WriteLine("Order placed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
