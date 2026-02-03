using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models
{
    public class Produto
    {
        #region Properties
        public long IdProduto { get; set; }
        public long IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        #endregion

        #region Navigation Properties

        // 1 Produto tem 1 categoria
        public Categoria Categoria { get; set; }

        #endregion
    }
}
