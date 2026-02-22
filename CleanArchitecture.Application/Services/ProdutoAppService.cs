using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.Application.Services;

public class ProdutoAppService : IprodutoAppService
{
    private readonly IProdutoService _produtoService;
    private readonly IMapper _mapper;

    public ProdutoAppService(IMapper mapper, IProdutoService produtoService)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }
    
    public async Task AdicionarProduto(ProdutoViewModel paramProduto)
    {
        var produto = _mapper.Map<Produto>(paramProduto);
        await _produtoService.Adicionar(produto);
    }

    public async Task Atualizar(ProdutoViewModel paramProduto)
    {
        var produto = _mapper.Map<Produto>(paramProduto);
        await _produtoService.Atualizar(produto);
    }

    public async Task Excluir(long id)
    {
        await _produtoService.Excluir(id);
    }

    public async Task<ProdutoViewModel> ObterPorId(long id)
    {
        return _mapper.Map<ProdutoViewModel>(await _produtoService.ObterPorId(id));

    }

    public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
    {
        var listaProdutos = await _produtoService.ObterTodos();
        var listaViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(listaProdutos);
        return listaViewModel;
    }
}