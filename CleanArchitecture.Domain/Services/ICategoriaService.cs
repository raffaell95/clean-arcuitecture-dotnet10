using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Services
{
    public interface ICategoriaService
    {
        Task Adicionar(Categoria categoria);
        Task<IEnumerable<Categoria>> ObterTodos();
        Task<Categoria> ObterPorId(long id);
        Task Atualizar(Categoria categoria);
        Task Excluir(long id);
    }
}
