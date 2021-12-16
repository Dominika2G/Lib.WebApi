// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Shared.Data.Entities
{
    // User
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");
            builder.HasKey(x => x.UserId).HasName("PK_User").IsClustered();

            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("bigint").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.PasswordHash).HasColumnName(@"PasswordHash").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("int").IsRequired();
            builder.Property(x => x.RoleId).HasColumnName(@"RoleId").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Class).HasColumnName(@"Class").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);

            // Foreign keys
            builder.HasOne(a => a.Role).WithMany(b => b.Users).HasForeignKey(c => c.RoleId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_User_Role");
        }
    }

}
// </auto-generated>
