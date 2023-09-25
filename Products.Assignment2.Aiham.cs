using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();

        while (true)
        {
            Console.WriteLine("Enter product details or 'q' to quit:");
            Console.Write("1. Category: ");
            string category = Console.ReadLine();

            if (category.ToLower() == "q")
                break;

            Console.Write("2. Product Name: ");
            string name = Console.ReadLine();

            Console.Write("3. Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Please enter a valid numeric value.");
                continue;
            }

            Product product = new Product(category, name, price);
            products.Add(product);
        }

        ShowProductList(products);

        while (true)
        {
            Console.Write("\nDo you want to add more products (Y/N)? ");
            string input = Console.ReadLine();
            if (input.ToLower() != "y")
                break;

            Console.WriteLine("Enter product details or 'q' to quit:");
            Console.Write("1. Category: ");
            string category = Console.ReadLine();

            if (category.ToLower() == "q")
                break;

            Console.Write("2. Product Name: ");
            string name = Console.ReadLine();

            Console.Write("3. Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Please enter a valid numeric value.");
                continue;
            }

            Product product = new Product(category, name, price);
            products.Add(product);
        }

        ShowProductList(products);

        //Level 4

            Console.Write("\nEnter a product name to search (or 'q' to quit): ");
            string searchQuery = Console.ReadLine();
            if (searchQuery.ToLower() != "q")
            {
            SearchProductList(products, searchQuery);
            }

    }

    static void ShowProductList(List<Product> products)
    {
        Console.WriteLine("\nList of Products (sorted by price):");
        products = products.OrderBy(p => p.Price).ToList();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Category} - {product.Name} - ${product.Price}");
        }

        decimal totalPrice = products.Sum(p => p.Price);
        Console.WriteLine($"\nTotal Price: ${totalPrice}");
    }

    static void SearchProductList(List<Product> products, String searchQuery)
        {
            List<Product> searchResults = products.Where(p => p.Name.ToLower().Contains(searchQuery.ToLower())).ToList();

            if (searchResults.Any())
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var product in searchResults)
                {
                    Console.WriteLine($"{product.Category} - {product.Name} - ${product.Price}");
                }
            }
            else
            {
                Console.WriteLine("No matching products found.");
            }

    }

}
class Product
{
    public string Category { get; }
    public string Name { get; }
    public decimal Price { get; }

    public Product(string category, string name, decimal price)
    {
        Category = category;
        Name = name;
        Price = price;
    }
}
