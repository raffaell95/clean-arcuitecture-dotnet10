using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryAppService _categoryService;

    public CategoryController(ICategoryAppService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var categories = await _categoryService.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var categories = await _categoryService.GetById(id);
        return Ok(categories);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> ToUpdate(long id, CategoryViewModel c)
    {
        c.IdCategory = id;
        await _categoryService.ToUpdate(c);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Add(CategoryViewModel category)
    {
        await _categoryService.AddCategory(category);
        return Ok();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Remove(long id)
    {
        await _categoryService.Remove(id);
        return Ok();
    }
}