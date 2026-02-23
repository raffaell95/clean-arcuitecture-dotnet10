using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.InfraStructure.Data;
using CleanArchitecture.InfraStructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.InfraStructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly CleanArchitectureContext _context;

    public ProductRepository(CleanArchitectureContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Product> GetByName(string name)
    {
        var product = await _context.Products.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        return product;
    }
}