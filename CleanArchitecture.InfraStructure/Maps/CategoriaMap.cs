using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.InfraStructure.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //configurar o nome da tabela
            builder.ToTable("CATEGORIA");

            builder.HasKey(x=> x.IdCategoria);

            builder.Property(x => x.IdCategoria).HasColumnName("ID_CATEGORIA")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao).HasColumnName("DESCRICAO");
            builder.Property(x => x.DataCadastro).HasColumnName("DAT_CADASTRO");

            //one to many ( 1 pra muitos ) 
            builder.HasMany(x=> x.Produtos).WithOne(y=> y.Categoria).HasForeignKey(y=>y.IdCategoria);
        }
    }
}
