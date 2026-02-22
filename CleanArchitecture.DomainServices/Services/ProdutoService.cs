using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Domain.Services;

namespace CleanArchitecture.DomainServices.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Adicionar(Produto produto)
    {
        await _repository.Adicionar(produto);
    }

    public async Task<IEnumerable<Produto>> ObterTodos()
    {
        var listaProdutos = await _repository.ObterTodos();
        return listaProdutos;
    }

    public async Task<Produto> ObterPorId(long id)
    {
        var produto = await _repository.ObterPorId(id);
        return produto;
    }

    public async Task Atualizar(Produto paramProduto)
    {
        var produto = await _repository.ObterPorId(paramProduto.IdProduto);
        if (produto == null)
            throw new ArgumentNullException("Produto nao encontrado");

        produto.Atualizar(paramProduto.Nome, paramProduto.Descricao, paramProduto.Preco);
        await _repository.Atualizar(produto);
    }

    public async Task Excluir(long id)
    {
        var produto = await _repository.ObterPorId(id);
        if (produto == null)
            throw new ArgumentNullException("Produto nao encontrado");
        
        await _repository.Excluir(id);
    }
}