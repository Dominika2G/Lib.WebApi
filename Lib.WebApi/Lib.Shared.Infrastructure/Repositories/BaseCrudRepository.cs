using Lib.Shared.Abstractions.Repositories;
using Lib.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Shared.Infrastructure.Repositories;

public abstract class BaseCrudRepository<TEntity> : BaseReadOnlyRepository<TEntity>, IBaseCrudRepository<TEntity> where TEntity : class
{
    protected BaseCrudRepository(IDatabaseContext context) : base(context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }

    private IDatabaseContext Context { get; }
    private DbSet<TEntity> DbSet { get; }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }
}
