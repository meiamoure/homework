namespace Task3;
public static class Solve4
{
    public static void Run()
    {
        var products = new List<Product>
        {
            new() { Title = "Beef", Category = "Meat", Price = 200},
            new() { Title = "Pork", Category = "Meat", Price = 120},
            new() { Title = "Bun", Category = "Bakery", Price = 50},
            new() { Title = "Bread", Category = "Bakery", Price = 25},
            new() { Title = "Cookies", Category = "Sweets", Price = 78},
            new() { Title = "Cake", Category = "Sweets", Price = 500}
        };

        var categories = products
                .GroupBy(product => product.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    AveragePrice = group.Average(p => p.Price),
                    Products = group
                });

        foreach (var category in categories)
        {
            Console.WriteLine($"Category: {category.Category}");
            Console.WriteLine($"Average: {category.AveragePrice:F2}");

            foreach (var product in category.Products)
            {
                Console.WriteLine($"  - {product.Title}");
            }
        }
    }
}
