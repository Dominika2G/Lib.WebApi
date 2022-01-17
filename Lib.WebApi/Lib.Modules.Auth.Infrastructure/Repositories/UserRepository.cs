using Lib.Modules.Auth.Domain.Interfaces;
using Lib.Shared.Data.Entities;
using Lib.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Infrastructure.Repositories;

public class UserRepository : BaseCrudRepository<User>, IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public bool CheckPassword(string userPassword, string dtoPassword)
    {
        if (userPassword == dtoPassword)
        {
            return true;
        }
        return false;
    }
}
