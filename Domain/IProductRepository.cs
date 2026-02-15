using System.Collections.Generic;

namespace ProductHexagonal.Domain;

public interface IProductRepository
{
    void Add(Product product);
    IEnumerable<Product> GetAll();
    void Delete(int id);
    IEnumerable<Product> SearchByName(string name);
}
