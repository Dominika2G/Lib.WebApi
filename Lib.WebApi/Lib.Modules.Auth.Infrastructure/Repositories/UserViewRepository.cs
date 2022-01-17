using Lib.Modules.Auth.Domain.Interfaces;
using Lib.Shared.Data.Entities;
using Lib.Shared.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Infrastructure.Repositories;

public class UserViewRepository : BaseCrudRepository<UserView>, IUserViewRepository
{
    private readonly DatabaseContext _context;

    public UserViewRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
