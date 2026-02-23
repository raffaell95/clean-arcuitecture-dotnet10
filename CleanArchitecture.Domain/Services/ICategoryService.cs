using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Services;

public interface ICategoryService
{
    Task Add(Category category);
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(long id);
    Task ToUpdate(Category category);
    Task Remove(long id);
}
