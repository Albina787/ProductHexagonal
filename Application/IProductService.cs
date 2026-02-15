using System.Collections.Generic;
using ProductHexagonal.Domain;

namespace ProductHexagonal.Application;

public interface IProductService
{
    void AddProduct(Product product);
    IEnumerable<Product> GetAllProducts();
    void DeleteProduct(int id);
    IEnumerable<Product> SearchProductsByName(string name);
}
