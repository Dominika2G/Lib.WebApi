using Lib.Shared.Abstractions.Repositories;
using Lib.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> query = DbSet;

        if (include != null)
            query = include(query);

        if (filter != null)
            query = query.Where(filter);

        return await query.FirstOrDefaultAsync().ConfigureAwait(false);
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> query = DbSet;

        if (include != null)
            query = include(query);

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return await query.ToListAsync().ConfigureAwait(false);
    }
}
