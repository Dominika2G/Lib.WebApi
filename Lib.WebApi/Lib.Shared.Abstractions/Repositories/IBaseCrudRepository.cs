using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Shared.Abstractions.Repositories;

public interface IBaseCrudRepository<TEntity> : IBaseReadOnlyRepository<TEntity>
{
    Task AddAsync(TEntity entity);
}
