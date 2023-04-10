using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockService.Domain.Entities;

namespace StockService.Domain.Config.Books;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id );
        
        builder.Property(b => b.Autor)
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(b => b.Name)
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(b => b.Publisher)
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(b => b.ReleaseDate)
            .HasColumnType("Date")
            .IsRequired();
    }
}