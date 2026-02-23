using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Application.Services;

public class CategoryAppService : ICategoryAppService
{

    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryAppService(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }
    
    public async Task AddCategory(CategoryViewModel paramCategory)
    {
        var validator = new CategoryValidator();
        var errorValidators = new List<string>();
        
        var category = _mapper .Map<Category>(paramCategory);
        
        var results = validator.Validate(category);
        results.Errors.ToList().ForEach(x => errorValidators.Add(x.ErrorMessage));
        if (errorValidators.Any())
            throw new ArgumentException("The following criticisms were found in Form: \n" +
                                        string.Join("\n", errorValidators));
        
        await _categoryService.Add(category);
    }

    public async Task ToUpdate(CategoryViewModel paramCategory)
    {
        var validator = new CategoryValidator();
        var errorValidators = new List<string>();
        
        var category = _mapper.Map<Category>(paramCategory);
        
        var results = validator.Validate(category);
        results.Errors.ToList().ForEach(x => errorValidators.Add(x.ErrorMessage));
        if (errorValidators.Any())
            throw new ArgumentException("The following criticisms were found in Form: \n" +
                                        string.Join("\n", errorValidators));
        
        await _categoryService.ToUpdate(category);
    }

    public async Task Remove(long id)
    {
        await _categoryService.Remove(id);
    }

    public async Task<CategoryViewModel> GetById(long id)
    {
        var category = _mapper.Map<CategoryViewModel>(await _categoryService.GetById(id));
        return category;
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAll()
    {
        var listCategories = await _categoryService.GetAll();
        var listViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(listCategories);
        return listViewModel;
    }
}