using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.DomainServices.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Add(Product product)
    {
        var p = await _repository.GetByName(product.Name);
        if (p != null)
            throw new ArgumentException("A product with that name already exists in the database.");
        
        await _repository.Add(product);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var listaProdutos = await _repository.GetAll();
        return listaProdutos;
    }

    public async Task<Product> GetById(long id)
    {
        var produto = await _repository.GetById(id);
        return produto;
    }

    public async Task ToUpdate(Product paramProduct)
    {
        var produto = await _repository.GetById(paramProduct.IdProduct);
        if (produto == null)
            throw new ArgumentNullException("Product not found");

        produto.ToUpdate(paramProduct.Name, paramProduct.Description, paramProduct.Price);
        await _repository.ToUpdate(produto);
    }

    public async Task Remove(long id)
    {
        var produto = await _repository.GetById(id);
        if (produto == null)
            throw new ArgumentNullException("Product not found");
        
        await _repository.Remove(id);
    }
}