using Lib.Modules.Auth.Domain.Interfaces;
using Lib.Shared.Data.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Infrastructure.Repositories
{

    public class UserRepository :  IUserRepository
    {
        public string getData()
        {
            return "MediatR działa";
        }
    }
}
