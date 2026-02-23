using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Services;

public interface IProductService
{
    Task Add(Product product);
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(long id);
    Task ToUpdate(Product product);
    Task Remove(long id);
}
