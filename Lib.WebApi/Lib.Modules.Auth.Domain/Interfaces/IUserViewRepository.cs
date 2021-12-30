using Lib.Shared.Abstractions.Repositories;
using Lib.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Domain.Interfaces;

public interface IUserViewRepository: IBaseCrudRepository<UserView>
{
}
