using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Domain.Dtos.User;

public class UserDetailDto
{
    public long UserId { get; set;}
    public string FirstName { get; set;}
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Class { get; set; }
    public int IsActive { get; set; }
    public string RoleName { get; set; }
}
