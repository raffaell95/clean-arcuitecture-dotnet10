using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Services;

public interface IProductAppService
{
    Task AddProduct(ProductViewModel paramProduct);
    Task ToUpdate(ProductViewModel product);
    Task Remove(long id);
    Task<ProductViewModel> GetById(long id);
    Task<IEnumerable<ProductViewModel>> GetAll();
}