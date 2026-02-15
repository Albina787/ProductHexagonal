using System;
using System.Collections.Generic;
using System.Linq;
using ProductHexagonal.Domain;

namespace ProductHexagonal.Infrastructure;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public void Add(Product product) => _products.Add(product);

    public IEnumerable<Product> GetAll() => _products;

    public void Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null) _products.Remove(product);
    }

    public IEnumerable<Product> SearchByName(string name) => 
        _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
}
