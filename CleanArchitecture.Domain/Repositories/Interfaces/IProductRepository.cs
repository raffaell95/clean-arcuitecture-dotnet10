using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repositories.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product> GetByName(string name);
}
