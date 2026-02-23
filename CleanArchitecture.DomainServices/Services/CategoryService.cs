using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.DomainServices.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task Add(Category category)
    {
        var c = await _repository.GetByName(category.Description);
        if (c != null)
            throw new ArgumentException("A category with that description already exists in the database.");

        await _repository.Add(category);
    }

    public async Task ToUpdate(Category paramCategory)
    {
        var categoria = await _repository.GetById(paramCategory.IdCategory);
        if (categoria == null)
            throw new ArgumentException("Category not found");

        categoria.ToUpdate(paramCategory.Description);

        await _repository.ToUpdate(categoria);
    }

    public async Task Remove(long id)
    {
        var categoria = await _repository.GetById(id);
        if (categoria == null)
            throw new ArgumentException("Category not found");

        await _repository.Remove(id);
    }

    public async Task<Category> GetById(long id)
    {
        var categoria = await _repository.GetById(id);
        return categoria;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _repository.GetAll();            
    }
}
