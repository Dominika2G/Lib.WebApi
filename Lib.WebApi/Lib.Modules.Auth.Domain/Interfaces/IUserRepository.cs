
using Lib.Modules.Auth.Domain.Dtos.Authenticated;
using Lib.Shared.Abstractions.Repositories;
using Lib.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Domain.Interfaces;

public interface IUserRepository: IBaseCrudRepository<User>
{
    bool CheckPassword(string userPassword, string dtoPassword);
}
