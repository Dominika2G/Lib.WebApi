using Lib.Shared.Abstractions.Repositories;
using Lib.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Shared.Infrastructure.Repositories;

public abstract class BaseReadOnlyRepository<TEntity> : IBaseReadOnlyRepository<TEntity> where TEntity : class
{
    protected BaseReadOnlyRepository(IDatabaseContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }

    private IDatabaseContext Context { get; }
    private DbSet<TEntity> DbSet { get; }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AnyAsync(predicate);
    }
}
