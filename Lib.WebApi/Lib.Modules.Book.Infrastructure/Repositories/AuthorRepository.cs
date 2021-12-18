using Lib.Modules.Book.Domain.Interfaces;
using Lib.Shared.Data.Entities;
using Lib.Shared.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Infrastructure.Repositories;

public class AuthorRepository : BaseCrudRepository<Author>, IAuthorRepository
{
    private readonly DatabaseContext _context;

    public AuthorRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
