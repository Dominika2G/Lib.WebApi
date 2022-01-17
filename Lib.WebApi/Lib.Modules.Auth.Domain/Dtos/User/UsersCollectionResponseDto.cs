using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Domain.Dtos.User;

public class UsersCollectionResponseDto
{
    public List<UserDetailDto> UsersCollection { get; set; }
}
