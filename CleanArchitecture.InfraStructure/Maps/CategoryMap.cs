using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.InfraStructure.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //configurar o nome da tabela
            builder.ToTable("category");

            builder.HasKey(x=> x.IdCategory);

            builder.Property(x => x.IdCategory).HasColumnName("id_category")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.DateRegistration).HasColumnName("date_registration");

            //one to many ( 1 pra muitos ) 
            builder.HasMany(x=> x.Products).WithOne(y=> y.Category).HasForeignKey(y=>y.IdCategory);
        }
    }
}
