// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lib.Shared.Data.Entities
{
    // UserView
    public class UserViewConfiguration : IEntityTypeConfiguration<UserView>
    {
        public void Configure(EntityTypeBuilder<UserView> builder)
        {
            builder.ToView("UserView", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.RoleName).HasColumnName(@"RoleName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("varchar(100)").IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.PasswordHash).HasColumnName(@"PasswordHash").HasColumnType("varchar(250)").IsRequired().IsUnicode(false).HasMaxLength(250);
            builder.Property(x => x.Class).HasColumnName(@"Class").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.IsActive).HasColumnName(@"IsActive").HasColumnType("bit").IsRequired();
            builder.Property(x => x.UserImg).HasColumnName(@"UserImg").HasColumnType("varbinary(max)").IsRequired(false);
            builder.Property(x => x.RoleId).HasColumnName(@"RoleId").HasColumnType("bigint").IsRequired();
        }
    }

}
// </auto-generated>
