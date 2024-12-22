namespace Task3;

public static class Solve7
{
    public static void Run()
    {
        var customers = new List<Customer>
        {
            new() { Name ="Andrii", LastName = "Shevchenko", Address = "Kyiv, Ukraine", Order = "Laptop", TotalPrice = 1200 },
            new() { Name = "Olena", LastName = "Petrenko", Address = "Lviv, Ukraine", Order = "Phone", TotalPrice = 800 },
            new() { Name = "Dmytro", LastName = "Koval", Address = "Kharkiv, Ukraine", Order = "TV", TotalPrice = 1500 },
            new() { Name = "Anna", LastName = "Ivanova", Address = "Odesa, Ukraine", Order = "Tablet", TotalPrice = 500 }
        };

        var filteredOrders = customers
        .Where(customer => customer.TotalPrice > 1000)
        .Select(customer => new { customer.Name, customer.LastName, customer.Order, customer.TotalPrice });

        foreach (var order in filteredOrders)
        {
            Console.WriteLine($"Name: {order.Name} {order.LastName}, Order: {order.Order}, Total price: {order.TotalPrice}");
        }
    }
}