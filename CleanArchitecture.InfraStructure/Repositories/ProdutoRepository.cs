using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.InfraStructure.Data;
using CleanArchitecture.InfraStructure.Repositories.Base;

namespace CleanArchitecture.InfraStructure.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly CleanArchitectureContext _context;

        public ProdutoRepository(CleanArchitectureContext context) : base(context)
        {
            _context = context;
        }
    }
}
