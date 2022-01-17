using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Shared.Data.Entities
{
    public class CommentsViewConfiguration: IEntityTypeConfiguration<CommentsView>
    {
        public void Configure(EntityTypeBuilder<CommentsView> builder)
        {
            builder.ToView("CommentsView", "dbo");
            builder.HasNoKey();

            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.BookId).HasColumnName(@"BookId").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.AddingDate).HasColumnName(@"AddingDate").HasColumnType("date").IsRequired();
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("varchar(100)").IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Rating).HasColumnName(@"Rating").HasColumnType("int").IsRequired();
            builder.Property(x => x.CommentId).HasColumnName(@"CommentId").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar(500)").IsRequired().IsUnicode(false).HasMaxLength(500);

        }
    }
}
