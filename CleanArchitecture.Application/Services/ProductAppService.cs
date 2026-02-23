using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductAppService(IMapper mapper, IProductService productService)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    public async Task AddProduct(ProductViewModel paramProduct)
    {
        var validator = new ProductValidator();
        var errorValidators = new List<string>();
        
        var product = _mapper.Map<Product>(paramProduct);
        
        var results = validator.Validate(product);
        results.Errors.ToList().ForEach(x => errorValidators.Add(x.ErrorMessage));
        if (errorValidators.Any())
            throw new ArgumentException("The following criticisms were found in Form: \n" +
                                        string.Join("\n", errorValidators));
        
        await _productService.Add(product);
    }

    public async Task ToUpdate(ProductViewModel paramProduct)
    {
        var validator = new ProductValidator();
        var errorValidators = new List<string>();

        var product = _mapper.Map<Product>(paramProduct);
        
        var results = validator.Validate(product);
        results.Errors.ToList().ForEach(x => errorValidators.Add(x.ErrorMessage));
        if (errorValidators.Any())
            throw new ArgumentException("The following criticisms were found in Form: \n" +
                                        string.Join("\n", errorValidators));
        
        await _productService.ToUpdate(product);
    }

    public async Task Remove(long id)
    {
        await _productService.Remove(id);
    }

    public async Task<ProductViewModel> GetById(long id)
    {
        return _mapper.Map<ProductViewModel>(await _productService.GetById(id));

    }

    public async Task<IEnumerable<ProductViewModel>> GetAll()
    {
        var listProducts = await _productService.GetAll();
        var listViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(listProducts);
        return listViewModel;
    }
}