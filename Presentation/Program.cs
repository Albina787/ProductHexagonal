using System;
using Microsoft.Extensions.DependencyInjection;
using ProductHexagonal.Domain;
using ProductHexagonal.Application;
using ProductHexagonal.Infrastructure;

class Program
{
    static async System.Threading.Tasks.Task Main()
    {
        var services = new ServiceCollection();

        // DI
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddHttpClient<IProductProxy, ProductProxy>();
        services.AddTransient<IProductService, ProductService>();

        var provider = services.BuildServiceProvider();
        var productService = provider.GetService<IProductService>();

        // Додаємо продукти
        productService?.AddProduct(new Product { Id = 1, Name = "Phone", Price = 999, Photo = "phone.jpg" });
        productService?.AddProduct(new Product { Id = 2, Name = "Laptop", Price = 1999, Photo = "laptop.jpg" });

        // Виводимо всі продукти
        Console.WriteLine("=== All Products ===");
        foreach (var p in productService!.GetAllProducts())
            Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} - {p.Photo}");

        // Пошук продукту
        Console.WriteLine("\n=== Search Products (\"Phone\") ===");
        foreach (var p in productService.SearchProductsByName("Phone"))
            Console.WriteLine($"{p.Id} - {p.Name}");

        // Приклад зовнішніх продуктів
        var proxy = provider.GetService<IProductProxy>();
        var externalProducts = await proxy!.GetProductsFromExternalAsync();
        Console.WriteLine("\n=== External Products (from API) ===");
        foreach (var p in externalProducts)
            Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}");
    }
}
