namespace CleanArchitecture.Domain.Models
{
    public class Categoria
    {
        #region Properties
        public long IdCategoria { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        #endregion

        #region Navigation Properties

        //1 categoria tem vários Produtos
        public List<Produto> Produtos { get; set; }

        #endregion

        public void Atualizar(string descricao)
        { 
            Descricao = descricao;
        }
    }
}
