using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductAppService _productAppService;
    
    public ProductController(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productAppService.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var products = await  _productAppService.GetById(id);
        return Ok(products);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> ToUpdate(ProductViewModel productVm)
    {
        await _productAppService.ToUpdate(productVm);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductViewModel productVm)
    {
        await _productAppService.AddProduct(productVm);
        return Ok();
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Remove(long id)
    {
        await _productAppService.Remove(id);
        return Ok();
    }
}