// <auto-generated>
// ReSharper disable All

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Shared.Data.Entities
{
    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; } // Author
        public DbSet<Book> Books { get; set; } // Book
        public DbSet<BookView> BookViews { get; set; } // BookView
        public DbSet<Borrow> Borrows { get; set; } // Borrows
        public DbSet<BorrowView> BorrowViews { get; set; } // BorrowView
        public DbSet<Comment> Comments { get; set; } // Comment
        public DbSet<CommentsView> CommentsView { get; set; }
        public DbSet<CommentsBook> CommentsBooks { get; set; } // CommentsBook
        public DbSet<Role> Roles { get; set; } // Role
        public DbSet<User> Users { get; set; } // User
        public DbSet<UserView> UserViews { get; set; } // UserView

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=D-GORALCZYK2\SQLEXPRESS;Initial Catalog=LibraryDB3;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookViewConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowViewConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CommentsViewConfiguration());
            modelBuilder.ApplyConfiguration(new CommentsBookConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserViewConfiguration());
        }

    }
}
// </auto-generated>
