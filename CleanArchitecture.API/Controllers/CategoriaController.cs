using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaAppService _categoriaService;

    public CategoriaController(ICategoriaAppService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var categorias = await _categoriaService.ObterTodos();
        return Ok(categorias);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> ObterPorId(long id)
    {
        var categoria = await _categoriaService.ObterPorId(id);
        return Ok(categoria);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Atualizar(long id, CategoriaViewModel c)
    {
        c.IdCategoria = id;
        await _categoriaService.Atualizar(c);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Cadastrar(CategoriaViewModel categoria)
    {
        await _categoriaService.AdicionarCategoria(categoria);
        return Ok();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Exluir(long id)
    {
        await _categoriaService.Excluir(id);
        return Ok();
    }
}