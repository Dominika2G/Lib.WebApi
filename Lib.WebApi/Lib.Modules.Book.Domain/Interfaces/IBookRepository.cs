using Lib.Shared.Abstractions.Repositories;
using Lib.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Interfaces;

public interface IBookRepository : IBaseCrudRepository<Lib.Shared.Data.Entities.Book>
{
    string getData();
}
