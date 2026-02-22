using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IprodutoAppService _produtoAppService;
    
    public ProdutoController(IprodutoAppService produtoAppService)
    {
        _produtoAppService = produtoAppService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var produtos = await _produtoAppService.ObterTodos();
        return Ok(produtos);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> ObterPorId(long id)
    {
        var produto = await  _produtoAppService.ObterPorId(id);
        return Ok(produto);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Atualizar(ProdutoViewModel produtoVm)
    {
        await _produtoAppService.Atualizar(produtoVm);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(ProdutoViewModel produtoVm)
    {
        await _produtoAppService.AdicionarProduto(produtoVm);
        return Ok();
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Excluir(long id)
    {
        await _produtoAppService.Excluir(id);
        return Ok();
    }
}