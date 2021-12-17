
using Lib.Shared.Abstractions.Repositories;
using Lib.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Modules.Auth.Domain.Interfaces;

public interface IUserRepository: IBaseCrudRepository<User>
{
    string getData();
}
