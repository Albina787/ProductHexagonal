using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductHexagonal.Domain;

namespace ProductHexagonal.Infrastructure;

public class ProductProxy : IProductProxy
{
    private readonly HttpClient _httpClient;

    public ProductProxy(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Product>> GetProductsFromExternalAsync()
    {
        var response = await _httpClient.GetStringAsync("https://fakestoreapi.com/products");
        return JsonSerializer.Deserialize<List<Product>>(response) ?? new List<Product>();
    }
}
