using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.InfraStructure.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(x => x.IdProduct);

            builder.Property(x => x.IdProduct).HasColumnName("id_product")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Price).HasColumnName("price");
            builder.Property(x => x.IdCategory).HasColumnName("id_category");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.DateRegistration).HasColumnName("date_registration");

            //many to one
            builder.HasOne(x => x.Category).WithMany(e => e.Products).HasForeignKey(e => e.IdCategory);

        }
    }
}
