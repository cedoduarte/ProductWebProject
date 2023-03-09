using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProduct.Model.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("nvarchar(256)")
                .HasDefaultValue("unnamed");
            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasColumnType("nvarchar(512)")
                .HasDefaultValue("none");
            builder.Property(x => x.Price)
                .IsRequired(true)
                .HasColumnType("decimal")
                .HasDefaultValue(0.0m);
            builder.Property(x => x.StockCount)
                .IsRequired(true)
                .HasColumnType("integer")
                .HasDefaultValue(0);
        }
    }
}
