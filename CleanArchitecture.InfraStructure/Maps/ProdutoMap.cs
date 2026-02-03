using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.InfraStructure.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            builder.HasKey(x => x.IdProduto);

            builder.Property(x => x.IdProduto).HasColumnName("ID_PRODUTO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Preco).HasColumnName("PRECO");
            builder.Property(x => x.IdCategoria).HasColumnName("ID_CATEGORIA");
            builder.Property(x => x.Descricao).HasColumnName("DESCRICAO");
            builder.Property(x => x.Nome).HasColumnName("NOME");
            builder.Property(x => x.DataCadastro).HasColumnName("DATA_CADASTRO");

            //many to one
            builder.HasOne(x => x.Categoria).WithMany(e => e.Produtos).HasForeignKey(e => e.IdCategoria);

        }
    }
}
