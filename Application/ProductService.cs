using System.Collections.Generic;
using ProductHexagonal.Domain;

namespace ProductHexagonal.Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IProductProxy _proxy;

    public ProductService(IProductRepository repository, IProductProxy proxy)
    {
        _repository = repository;
        _proxy = proxy;
    }

    public void AddProduct(Product product) => _repository.Add(product);

    public IEnumerable<Product> GetAllProducts() => _repository.GetAll();

    public void DeleteProduct(int id) => _repository.Delete(id);

    public IEnumerable<Product> SearchProductsByName(string name) => _repository.SearchByName(name);
}
