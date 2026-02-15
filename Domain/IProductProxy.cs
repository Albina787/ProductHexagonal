using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductHexagonal.Domain;

public interface IProductProxy
{
    Task<IEnumerable<Product>> GetProductsFromExternalAsync();
}
