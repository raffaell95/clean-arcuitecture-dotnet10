using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Repositories.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task<Categoria> ObterPorNome(string nome);
    }
}
