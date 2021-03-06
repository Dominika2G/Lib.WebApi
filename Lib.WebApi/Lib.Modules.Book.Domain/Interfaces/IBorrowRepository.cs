using Lib.Shared.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Interfaces;

public interface IBorrowRepository: IBaseCrudRepository<Lib.Shared.Data.Entities.Borrow>
{
}
