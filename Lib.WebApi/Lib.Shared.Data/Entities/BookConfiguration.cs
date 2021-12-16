// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Shared.Data.Entities
{
    // Book
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book", "dbo");
            builder.HasKey(x => x.BookId).HasName("PK_Book").IsClustered();

            builder.Property(x => x.BookId).HasColumnName(@"BookId").HasColumnType("bigint").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.AuthorId).HasColumnName(@"AuthorId").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar(250)").IsRequired().IsUnicode(false).HasMaxLength(250);
            builder.Property(x => x.Cover).HasColumnName(@"Cover").HasColumnType("varchar(250)").IsRequired().IsUnicode(false).HasMaxLength(250);
            builder.Property(x => x.BarCode).HasColumnName(@"BarCode").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);

            // Foreign keys
            builder.HasOne(a => a.Author).WithMany(b => b.Books).HasForeignKey(c => c.AuthorId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Book_Author");
        }
    }

}
// </auto-generated>