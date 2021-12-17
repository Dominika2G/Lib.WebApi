using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Shared.Abstractions.Repositories;

public interface IBaseReadOnlyRepository<TEntity>
{
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
}
