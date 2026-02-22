namespace CleanArchitecture.Application.ViewModels;

public class ProdutoViewModel
{

    public long Id { get; set; }
    public long IdCategoria { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataCadastro { get; set; }
    
}