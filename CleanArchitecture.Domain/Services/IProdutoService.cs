using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Services
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(long id);
        Task Atualizar(Produto produto);
        Task Excluir(long id);
    }
}
