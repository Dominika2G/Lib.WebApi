// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Shared.Data.Entities
{
    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // Author
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author", "dbo");
            builder.HasKey(x => x.AuthorId).HasName("PK_Author").IsClustered();

            builder.Property(x => x.AuthorId).HasColumnName(@"AuthorId").HasColumnType("bigint").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
        }
    }

}
// </auto-generated>