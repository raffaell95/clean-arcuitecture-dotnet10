using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.InfraStructure.Data;
using CleanArchitecture.InfraStructure.Repositories.Base;

namespace CleanArchitecture.InfraStructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly CleanArchitectureContext _context;

        public CategoriaRepository(CleanArchitectureContext context) : base(context) 
        {
            _context = context;
        }

        public Task<Categoria> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
