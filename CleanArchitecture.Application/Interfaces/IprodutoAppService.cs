using CleanArchitecture.Application.ViewModels;

namespace CleanArchitecture.Application.Services;

public interface IprodutoAppService
{
    Task AdicionarProduto(ProdutoViewModel produto);
    Task Atualizar(ProdutoViewModel produto);
    Task Excluir(long id);
    Task<ProdutoViewModel> ObterPorId(long id);
    Task<IEnumerable<ProdutoViewModel>> ObterTodos();
}