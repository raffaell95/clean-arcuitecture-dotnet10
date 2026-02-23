using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Interfaces;

public interface ICategoryAppService
{
    Task AddCategory(CategoryViewModel category);
    Task ToUpdate(CategoryViewModel category);
    Task Remove(long id);
    Task<CategoryViewModel> GetById(long id);
    Task<IEnumerable<CategoryViewModel>> GetAll();
}