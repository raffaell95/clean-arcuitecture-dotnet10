using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.InfraStructure.Data;
using CleanArchitecture.InfraStructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.InfraStructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    private readonly CleanArchitectureContext _context;

    public CategoryRepository(CleanArchitectureContext context) : base(context) 
    {
        _context = context;
    }

    public async Task<Category> GetByName(string name)
    {
        var category = await _context.Categories.Where(x => x.Description.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        return category;
    }
}