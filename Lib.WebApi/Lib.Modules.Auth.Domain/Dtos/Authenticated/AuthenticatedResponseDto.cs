using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Domain.Dtos.Authenticated;

public class AuthenticatedResponseDto
{
    public string Token { get; set; }
    public long RoleId { get; set; }
    public long UserId { get; set; }
}
