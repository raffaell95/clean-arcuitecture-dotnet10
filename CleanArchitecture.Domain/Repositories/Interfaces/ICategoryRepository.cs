using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetByName(string name);
}
